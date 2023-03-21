using Quizinator.Models.Quizzes;
using ReactiveUI;

namespace Quizinator.ViewModels.Quizzes.Factory;

public interface IQuizResultsViewModelFactory
{
    IQuizResultsViewModel Create(IScreen hostScreen, Quiz quiz, IRoutableViewModel viewModelToReturn);
}