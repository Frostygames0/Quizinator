using Quizinator.Models.Quizzes;
using ReactiveUI;

namespace Quizinator.ViewModels.Quizzes.Factory;

public class QuizIntroViewModelFactory : IQuizIntroViewModelFactory
{
    public IQuizIntroViewModel Create(IScreen hostScreen, Quiz quiz)
    {
        return new QuizIntroViewModel(hostScreen, quiz);
    }
}