using System.Windows.Input;
using ReactiveUI;

namespace Quizinator.ViewModels.Quiz;

public interface IQuizResultsViewModel : IRoutableViewModel
{
    string ResultsFormatted { get; }
    
    public ICommand Back { get; }
}