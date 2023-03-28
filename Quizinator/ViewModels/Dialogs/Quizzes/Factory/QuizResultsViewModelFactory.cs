using Quizinator.Models.Quizzes;
using ReactiveUI;

namespace Quizinator.ViewModels.Dialogs.Quizzes.Factory;

public class QuizResultsViewModelFactory : IQuizResultsViewModelFactory
{
    public IQuizResultsViewModel Create(IScreen hostScreen, Quiz quiz)
    {
        return new QuizResultsViewModel(hostScreen, quiz);
    }
}