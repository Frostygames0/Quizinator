using Quizinator.Models.Quizzes;
using ReactiveUI;

namespace Quizinator.ViewModels.Quizzes.Factory;

public class QuizResultsViewModelFactory : IQuizResultsViewModelFactory
{
    public IQuizResultsViewModel Create(IScreen hostScreen, Quiz quiz, IRoutableViewModel viewModelToReturn)
    {
        return new QuizResultsViewModel(hostScreen, quiz, viewModelToReturn);
    }
}