using Quizinator.Models;
using ReactiveUI;

namespace Quizinator.ViewModels.Quiz.Factory;

public class QuestionViewModelFactory : IQuestionViewModelFactory
{
    public IQuestionViewModel Create(IScreen hostScreen, Question question)
    {
        return new QuestionViewModel(hostScreen, question);
    }
}