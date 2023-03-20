using System.Windows.Input;
using ReactiveUI;

namespace Quizinator.ViewModels.Quiz;

public interface IQuizViewModel : IScreen, IRoutableViewModel
{
    public ICommand Next { get; }
}