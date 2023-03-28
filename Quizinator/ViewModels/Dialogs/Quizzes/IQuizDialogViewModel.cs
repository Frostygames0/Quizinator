using System.Windows.Input;
using ReactiveUI;

namespace Quizinator.ViewModels.Dialogs.Quizzes;

public interface IQuizDialogViewModel : IScreen
{
    public bool ReachedEnd { get; }

    public ICommand Next { get; }
}