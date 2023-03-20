using ReactiveUI;

namespace Quizinator.ViewModels.Quiz.Factory;

public class QuizResultsViewModelFactory : IQuizResultsViewModelFactory
{
    public IQuizResultsViewModel Create(IScreen hostScreen, Models.Quiz quiz, IRoutableViewModel viewModelToReturn)
    {
        return new QuizResultsViewModel(hostScreen, quiz, viewModelToReturn);
    }
}