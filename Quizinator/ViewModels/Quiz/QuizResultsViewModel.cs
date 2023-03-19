using System.Reactive;
using ReactiveUI;

namespace Quizinator.ViewModels.Quiz;

public class QuizResultsViewModel : ViewModelBase, IRoutableViewModel, IActivatableViewModel
{
    public string ResultsFormatted { get; }
    
    public ViewModelActivator Activator { get; } = new();
    public string? UrlPathSegment { get; }
    public IScreen HostScreen { get; }
    
    public ReactiveCommand<Unit, IRoutableViewModel> Back { get; }
    
    public QuizResultsViewModel(IScreen hostScreen, Models.Quiz quiz)
    {
        HostScreen = hostScreen;
        UrlPathSegment = "quiz_results";
        
        ResultsFormatted = $"{quiz.CalculateResults()}/{quiz.Questions.Count}"; // TODO IDK IF THIS CORRECT (BUT WORKS)
        
        Back = ReactiveCommand.CreateFromObservable(
            () => hostScreen.Router.NavigateAndReset.Execute(new MainMenuViewModel(hostScreen, Directories.Quizzes)));
    }
}