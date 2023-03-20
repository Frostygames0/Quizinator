using System.Windows.Input;
using ReactiveUI;

namespace Quizinator.ViewModels.Quiz;

public class QuizResultsViewModel : ViewModelBase, IQuizResultsViewModel
{
    private IRoutableViewModel _viewModelToReturn;
    
    public string ResultsFormatted { get; }

    public ViewModelActivator Activator { get; } = new();
    public string? UrlPathSegment { get; }
    public IScreen HostScreen { get; }
    
    public ICommand Back { get; }
    
    public QuizResultsViewModel(IScreen hostScreen, Models.Quiz quiz, IRoutableViewModel viewModelToReturn)
    {
        HostScreen = hostScreen;
        UrlPathSegment = "quiz_results";

        _viewModelToReturn = viewModelToReturn;
        
        ResultsFormatted = $"{quiz.CalculateResults()}/{quiz.Questions.Count}"; // TODO IDK IF THIS CORRECT (BUT WORKS)
        
        Back = ReactiveCommand.CreateFromObservable(
            () => hostScreen.Router.NavigateAndReset.Execute(_viewModelToReturn));
    }
}