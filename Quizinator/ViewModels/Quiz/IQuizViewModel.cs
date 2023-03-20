using System.Windows.Input;
using ReactiveUI;

namespace Quizinator.ViewModels.Quiz;

public interface IQuizViewModel : IScreen, IRoutableViewModel, IActivatableViewModel
{
    public ICommand Next { get; }
}