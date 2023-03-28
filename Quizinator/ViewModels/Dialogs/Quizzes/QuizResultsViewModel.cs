using Quizinator.Models.Quizzes;
using ReactiveUI;

namespace Quizinator.ViewModels.Dialogs.Quizzes;

public class QuizResultsViewModel : ViewModelBase, IQuizResultsViewModel
{
    public string ResultsFormatted { get; }
    
    public string? UrlPathSegment { get; }
    public IScreen HostScreen { get; }

    public QuizResultsViewModel(IScreen hostScreen, Quiz quiz)
    {
        HostScreen = hostScreen;
        UrlPathSegment = "quiz_results";

        ResultsFormatted = $"{quiz.CalculateResults()}/{quiz.Questions.Count}"; // TODO IDK IF THIS CORRECT (BUT WORKS)
    }
}