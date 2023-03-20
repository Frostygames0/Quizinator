using ReactiveUI;

namespace Quizinator.ViewModels.Quiz.Factory;

public class QuizIntroViewModelFactory : IQuizIntroViewModelFactory
{
    public IQuizIntroViewModel Create(IScreen hostScreen, Models.Quiz quiz)
    {
        return new QuizIntroViewModel(hostScreen, quiz);
    }
}