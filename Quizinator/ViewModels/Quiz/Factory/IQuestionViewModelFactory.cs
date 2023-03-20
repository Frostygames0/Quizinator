using Quizinator.Models;
using ReactiveUI;

namespace Quizinator.ViewModels.Quiz.Factory;

public interface IQuestionViewModelFactory
{
    IQuestionViewModel Create(IScreen hostScreen, Question question);
}