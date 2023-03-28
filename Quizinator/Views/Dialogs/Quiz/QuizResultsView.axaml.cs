using Avalonia.ReactiveUI;
using Quizinator.ViewModels.Dialogs.Quizzes;

namespace Quizinator.Views.Dialogs.Quiz;

public partial class QuizResultsView : ReactiveUserControl<QuizResultsViewModel>
{
    public QuizResultsView() 
        => InitializeComponent();
}