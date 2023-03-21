using Quizinator.Models.Quizzes;
using ReactiveUI;

namespace Quizinator.ViewModels.Quizzes.Factory;

public interface IQuizViewModelFactory
{
    IQuizViewModel Create(IScreen hostScreen, Quiz quiz, IRoutableViewModel viewModelToReturn);
}