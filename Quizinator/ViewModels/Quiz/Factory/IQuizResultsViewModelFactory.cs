using ReactiveUI;

namespace Quizinator.ViewModels.Quiz.Factory;

public interface IQuizResultsViewModelFactory
{
    IQuizResultsViewModel Create(IScreen hostScreen, Models.Quiz quiz, IRoutableViewModel viewModelToReturn);
}