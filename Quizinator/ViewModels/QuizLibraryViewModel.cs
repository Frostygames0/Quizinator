using System.Collections.ObjectModel;
using System.Reactive;
using Quizinator.Models;
using ReactiveUI;

namespace Quizinator.ViewModels;

public class QuizLibraryViewModel : ViewModelBase, IRoutableViewModel
{
    private QuizViewModel? _chosenQuiz;

    public QuizViewModel? ChosenQuiz
    {
        get => _chosenQuiz;
        set => this.RaiseAndSetIfChanged(ref _chosenQuiz, value);
    }

    public ObservableCollection<Quiz> FoundQuizzes { get; }
    
    public ReactiveCommand<Unit, IRoutableViewModel> ReturnToMenu { get; }
    
    public string? UrlPathSegment { get; }
    public IScreen HostScreen { get; }

    public QuizLibraryViewModel(IScreen hostScreen, Interaction<CreateQuizViewModel, string?> openDialog)
    {
        HostScreen = hostScreen;
        UrlPathSegment = "quiz_library";

        FoundQuizzes = new ObservableCollection<Quiz>();

        ReturnToMenu = ReactiveCommand.CreateFromObservable(() => hostScreen.Router.NavigateAndReset.Execute(new MenuViewModel(hostScreen, openDialog)));
    }
}