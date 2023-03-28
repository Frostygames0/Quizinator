using System.Windows.Input;

namespace Quizinator.ViewModels;

public interface IMainMenuViewModel
{
    ILibraryViewModel LibraryViewModel { get; }
    
    ICommand NewQuiz { get; }
    ICommand BeginQuiz { get; }
    ICommand OpenSettings { get; }
}