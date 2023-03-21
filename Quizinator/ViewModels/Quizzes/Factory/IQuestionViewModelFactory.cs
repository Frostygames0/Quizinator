using Quizinator.Models.Quizzes;
using ReactiveUI;

namespace Quizinator.ViewModels.Quizzes.Factory;

public interface IQuestionViewModelFactory
{
    IQuestionViewModel Create(IScreen hostScreen, Question question);
}