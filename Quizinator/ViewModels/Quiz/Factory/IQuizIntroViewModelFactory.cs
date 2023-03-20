using ReactiveUI;

namespace Quizinator.ViewModels.Quiz.Factory;

public interface IQuizIntroViewModelFactory
{
    IQuizIntroViewModel Create(IScreen hostScreen, Models.Quiz quiz);
}