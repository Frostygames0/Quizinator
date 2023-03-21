using System.Windows.Input;
using ReactiveUI;

namespace Quizinator.ViewModels.Quizzes;

public interface IQuizViewModel : IScreen, IRoutableViewModel
{
    public ICommand Next { get; }
}