using ReactiveUI;

namespace Quizinator.ViewModels.Quiz;

public interface IQuizIntroViewModel : IRoutableViewModel
{
    string Name { get; }
    string Description { get; }
    string Author { get; }

    int QuestionCount { get; }
}