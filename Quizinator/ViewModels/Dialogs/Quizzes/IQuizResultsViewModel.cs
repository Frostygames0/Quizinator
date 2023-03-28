using ReactiveUI;

namespace Quizinator.ViewModels.Dialogs.Quizzes;

public interface IQuizResultsViewModel : IRoutableViewModel
{
    string ResultsFormatted { get; }
}