using System.Windows.Input;
using Quizinator.Models.Quizzes;
using ReactiveUI;

namespace Quizinator.ViewModels.Quizzes;

public class QuizResultsViewModel : ViewModelBase, IQuizResultsViewModel
{
    private IRoutableViewModel _viewModelToReturn;
    
    public string ResultsFormatted { get; }
    
    public string? UrlPathSegment { get; }
    public IScreen HostScreen { get; }
    
    public ICommand Back { get; }
    
    public QuizResultsViewModel(IScreen hostScreen, Quiz quiz, IRoutableViewModel viewModelToReturn)
    {
        HostScreen = hostScreen;
        UrlPathSegment = "quiz_results";

        _viewModelToReturn = viewModelToReturn;
        
        ResultsFormatted = $"{quiz.CalculateResults()}/{quiz.Questions.Count}"; // TODO IDK IF THIS CORRECT (BUT WORKS)
        
        Back = ReactiveCommand.CreateFromObservable(
            () => hostScreen.Router.NavigateAndReset.Execute(_viewModelToReturn));
    }
}