using System.Collections.ObjectModel;
using System.Windows.Input;
using Quizinator.Models.Quizzes;

namespace Quizinator.ViewModels;

public interface ILibraryViewModel
{
    string? SearchFolder { get; set; }
    Quiz? SelectedQuiz { get; set; }
    
    ObservableCollection<Quiz> FoundQuizzes { get; }
    
    ICommand RefreshSearch { get; }
    ICommand OpenSearchFolder { get; }
}