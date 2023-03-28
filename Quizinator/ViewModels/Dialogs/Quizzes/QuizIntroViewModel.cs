using Quizinator.Models.Quizzes;
using ReactiveUI;

namespace Quizinator.ViewModels.Dialogs.Quizzes;

public class QuizIntroViewModel : ViewModelBase, IQuizIntroViewModel
{
    private readonly Quiz _quiz;
    
    public string Name => _quiz.Name;
    public string Description => _quiz.Description;
    public string Author => _quiz.Author;

    public int QuestionCount => _quiz.Questions.Count;
    
    public string? UrlPathSegment { get; }
    public IScreen HostScreen { get; }

    public QuizIntroViewModel(IScreen hostScreen, Quiz quiz)
    {
        HostScreen = hostScreen;
        UrlPathSegment = "quiz_intro";

        _quiz = quiz;
    }
}