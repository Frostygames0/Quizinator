using ReactiveUI;

namespace Quizinator.ViewModels.Quiz;

public class QuizIntroViewModel : ViewModelBase, IRoutableViewModel
{
    private readonly Models.Quiz _quiz;
    
    public string Name => _quiz.Name;
    public string Description => _quiz.Description;
    public string Author => _quiz.Author;

    public int QuestionCount => _quiz.Questions.Count;
    
    public string? UrlPathSegment { get; }
    public IScreen HostScreen { get; }

    public QuizIntroViewModel(IScreen hostScreen, Models.Quiz quiz)
    {
        HostScreen = hostScreen;
        UrlPathSegment = "quiz_intro";

        _quiz = quiz;
    }
}