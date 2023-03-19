using System;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Reactive.Disposables;
using System.Threading.Tasks;
using DynamicData;
using Quizinator.Extensions;
using Quizinator.Models;
using Quizinator.ViewModels.Quiz;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Splat;

namespace Quizinator.ViewModels;

[Obsolete("Merged into MainMenuViewModel")]
public class LibraryViewModel : ViewModelBase, IRoutableViewModel, IActivatableViewModel
{
    private readonly IQuizSearcher _quizSearcher;
    
    [Reactive]
    public Models.Quiz? SelectedQuiz { get; set; }

    public ObservableCollection<Models.Quiz> FoundQuizzes { get; }

    public ReactiveCommand<Unit, IRoutableViewModel> ReturnToMenu { get; }
    public ReactiveCommand<Unit, bool> RefreshSearch { get; }
    public ReactiveCommand<Unit, IRoutableViewModel> Start { get; }

    public string? UrlPathSegment { get; }
    public IScreen HostScreen { get; }

    public ViewModelActivator Activator { get; } = new();
    
    public LibraryViewModel(IScreen hostScreen, string? searchLocation = null, IQuizSearcher? quizSearcher = null)
    {
        HostScreen = hostScreen;
        UrlPathSegment = "quiz_library";

        FoundQuizzes = new ObservableCollection<Models.Quiz>();
        _quizSearcher = quizSearcher ?? Locator.Current.GetImportantService<IQuizSearcher>();

        var hostRouter = HostScreen.Router;
        ReturnToMenu = ReactiveCommand.CreateFromObservable(
            () => hostRouter.NavigateAndReset.Execute(new MenuViewModel(hostScreen))); // TODO make factory for this or service
        
        Start = ReactiveCommand.CreateFromObservable(
            () => hostRouter.NavigateAndReset.Execute(new QuizViewModel(hostScreen, SelectedQuiz))); // TODO make factory for this or service

        RefreshSearch = ReactiveCommand.CreateFromTask(() => RefreshFoundQuizzes(searchLocation));
        this.WhenActivated((CompositeDisposable disposables) => RefreshSearch.Execute());
    }
    
    // TODO I don't really like this, maybe quiz searcher should use rx to update search?
    private async Task<bool> RefreshFoundQuizzes(string? searchLocation)
    {
        bool updated = await _quizSearcher.TrySearch(searchLocation);
        if (!updated) 
            return updated;
            
        FoundQuizzes.Clear();
        FoundQuizzes.AddRange(_quizSearcher.FoundQuizzes);

        return updated;
    }
}