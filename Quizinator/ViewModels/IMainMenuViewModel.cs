using System.Windows.Input;
using ReactiveUI;

namespace Quizinator.ViewModels;

public interface IMainMenuViewModel : IRoutableViewModel
{
    ILibraryViewModel LibraryViewModel { get; }
    
    ICommand NewQuiz { get; }
    ICommand BeginQuiz { get; }
    ICommand OpenSettings { get; }
}