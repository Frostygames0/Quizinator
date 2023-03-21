using Quizinator.Models.Quizzes;
using ReactiveUI;

namespace Quizinator.ViewModels.Quizzes.Factory;

public class QuestionViewModelFactory : IQuestionViewModelFactory
{
    public IQuestionViewModel Create(IScreen hostScreen, Question question)
    {
        return new QuestionViewModel(hostScreen, question);
    }
}