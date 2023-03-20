using ReactiveUI;

namespace Quizinator.ViewModels.Quiz.Factory;

public interface IQuizViewModelFactory
{
    IQuizViewModel Create(IScreen hostScreen, Models.Quiz quiz, IRoutableViewModel viewModelToReturn);
}