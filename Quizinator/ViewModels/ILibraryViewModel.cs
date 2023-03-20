using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Quizinator.ViewModels;

public interface ILibraryViewModel
{
    string? SearchFolder { get; set; }
    Models.Quiz? SelectedQuiz { get; set; }
    
    ObservableCollection<Models.Quiz> FoundQuizzes { get; }
    
    ICommand RefreshSearch { get; }
    ICommand OpenSearchFolder { get; }
}