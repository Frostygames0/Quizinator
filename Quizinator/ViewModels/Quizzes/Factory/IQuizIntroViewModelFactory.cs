using Quizinator.Models.Quizzes;
using ReactiveUI;

namespace Quizinator.ViewModels.Quizzes.Factory;

public interface IQuizIntroViewModelFactory
{
    IQuizIntroViewModel Create(IScreen hostScreen, Quiz quiz);
}