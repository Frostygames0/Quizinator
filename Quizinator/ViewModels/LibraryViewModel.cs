using System.Collections.ObjectModel;
using System.Reactive;
using System.Reactive.Disposables;
using DynamicData;
using Quizinator.ViewModels.Quiz;
using ReactiveUI;

namespace Quizinator.ViewModels;

public class LibraryViewModel : ViewModelBase, IRoutableViewModel, IActivatableViewModel
{
    private Models.Quiz? _selectedQuiz;

    public Models.Quiz? SelectedQuiz
    {
        get => _selectedQuiz;
        set => this.RaiseAndSetIfChanged(ref _selectedQuiz, value);
    }
    
    public ObservableCollection<Models.Quiz> FoundQuizzes { get; }

    public ReactiveCommand<Unit, IRoutableViewModel> ReturnToMenu { get; }
    public ReactiveCommand<Unit, Unit> RefreshSearch { get; }
    public ReactiveCommand<Unit, IRoutableViewModel> Start { get; }

    public string? UrlPathSegment { get; }
    public IScreen HostScreen { get; }

    public ViewModelActivator Activator { get; } = new();

    public LibraryViewModel(IScreen hostScreen, string searchLocation)
    {
        HostScreen = hostScreen;
        UrlPathSegment = "quiz_library";

        FoundQuizzes = new ObservableCollection<Models.Quiz>();

        ReturnToMenu = ReactiveCommand.CreateFromObservable(
            () => hostScreen.Router.NavigateAndReset.Execute(new MenuViewModel(hostScreen)));

        Start = ReactiveCommand.CreateFromObservable(
            () => hostScreen.Router.NavigateAndReset.Execute(new QuizViewModel(hostScreen, SelectedQuiz)));

        RefreshSearch = ReactiveCommand.Create(() => RefreshFoundQuizzes(searchLocation));
        this.WhenActivated((CompositeDisposable disposables) =>
        {
            RefreshFoundQuizzes(searchLocation);
        });
    }

    private async void RefreshFoundQuizzes(string searchLocation)
    {
        FoundQuizzes.Clear();
        var quizzes = await Models.Quiz.FindQuizzesAsync(searchLocation);
        FoundQuizzes.AddRange(quizzes);
    }
}