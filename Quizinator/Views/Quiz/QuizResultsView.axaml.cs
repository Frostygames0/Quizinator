using Avalonia.ReactiveUI;
using Quizinator.ViewModels.Quizzes;

namespace Quizinator.Views.Quiz;

public partial class QuizResultsView : ReactiveUserControl<QuizResultsViewModel>
{
    public QuizResultsView() 
        => InitializeComponent();
}