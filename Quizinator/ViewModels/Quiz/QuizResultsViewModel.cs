using System.Reactive;
using ReactiveUI;

namespace Quizinator.ViewModels;

public class QuizResultsViewModel : ViewModelBase, IRoutableViewModel, IActivatableViewModel
{
    public string ResultsFormatted { get; }
    
    public ViewModelActivator Activator { get; } = new();
    public string? UrlPathSegment { get; }
    public IScreen HostScreen { get; }
    
    public ReactiveCommand<Unit, IRoutableViewModel> GoBackToMenu { get; }

    public QuizResultsViewModel(IScreen hostScreen, Models.Quiz quiz)
    {
        HostScreen = hostScreen;
        UrlPathSegment = "quiz_results";
        
        ResultsFormatted = $"{quiz.CalculateResults()}/{quiz.Questions.Count}"; // TODO IDK IF THIS CORRECT (BUT WORKS)
        
        GoBackToMenu = ReactiveCommand.CreateFromObservable(
            () => hostScreen.Router.NavigateAndReset.Execute(new MenuViewModel(hostScreen)));
    }
}