using System.Collections.ObjectModel;
using System.Reactive;
using System.Reactive.Disposables;
using System.Threading.Tasks;
using DynamicData;
using Quizinator.Extensions;
using Quizinator.Models;
using Quizinator.Models.Dialog;
using Quizinator.ViewModels.Dialogs;
using Quizinator.ViewModels.Quiz;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Splat;

namespace Quizinator.ViewModels;

// TODO too big :( decompose maybe or maybe it's ok for a view model
public class MainMenuViewModel : ViewModelBase, IRoutableViewModel, IActivatableViewModel
{
    private readonly IQuizSearcher _quizSearcher;
    private readonly IDialogDisplayer _dialogDisplayer;
    private readonly ISystemDialogDisplayer _systemDialogDisplayer;
    
    [Reactive] public Models.Quiz? SelectedQuiz { get; set; }
    [Reactive] public string? SearchFolder { get; set; }
    
    public ObservableCollection<Models.Quiz> FoundQuizzes { get; }
    
    public ReactiveCommand<Unit, bool> RefreshSearch { get; }
    public ReactiveCommand<Unit, string?> OpenSearchFolder { get; }

    public ReactiveCommand<Unit, Unit> NewQuiz { get; }
    public ReactiveCommand<Unit, IRoutableViewModel> BeginQuiz { get; }
    public ReactiveCommand<Unit, Unit> OpenSettings { get; }

    public string? UrlPathSegment { get; }
    public IScreen HostScreen { get; }

    public ViewModelActivator Activator { get; } = new();
    
    public MainMenuViewModel(IScreen hostScreen, string? searchLocation = null,
        IQuizSearcher? quizSearcher = null, IDialogDisplayer? dialogDisplayer = null, ISystemDialogDisplayer? systemDialogDisplayer = null)
    {
        HostScreen = hostScreen;
        UrlPathSegment = "quiz_library";
        
        _quizSearcher = quizSearcher ?? Locator.Current.GetImportantService<IQuizSearcher>();
        _dialogDisplayer = dialogDisplayer ?? Locator.Current.GetImportantService<IDialogDisplayer>();
        _systemDialogDisplayer = systemDialogDisplayer ?? Locator.Current.GetImportantService<ISystemDialogDisplayer>();

        FoundQuizzes = new ObservableCollection<Models.Quiz>();
        SearchFolder = searchLocation;

        var hostRouter = HostScreen.Router;
        NewQuiz = ReactiveCommand.CreateFromTask(async () =>
        {
            var result = await _dialogDisplayer.ShowDialogAsync<CreateQuizDialogViewModel, string>(new CreateQuizDialogViewModel());
        });
        BeginQuiz = ReactiveCommand.CreateFromObservable(
            () => hostRouter.NavigateAndReset.Execute(new QuizViewModel(hostScreen, SelectedQuiz))); // TODO make factory for this or service
        OpenSettings = ReactiveCommand.Create(() => {});

        RefreshSearch = ReactiveCommand.CreateFromTask(() => RefreshFoundQuizzes(searchLocation));
        OpenSearchFolder = ReactiveCommand.CreateFromTask(() => _systemDialogDisplayer.OpenFolder(searchLocation));
        
        this.WhenActivated((CompositeDisposable disposables) => RefreshSearch.Execute());
    }
    
    // TODO I don't really like this, maybe quiz searcher should use rx to update search?
    private async Task<bool> RefreshFoundQuizzes(string? searchLocation)
    {
        bool updated = await _quizSearcher.TryUpdateSearch(searchLocation);
        if (!updated) 
            return updated;
            
        FoundQuizzes.Clear();
        FoundQuizzes.AddRange(_quizSearcher.FoundQuizzes);

        return updated;
    }
}