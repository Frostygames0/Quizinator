using Avalonia.ReactiveUI;
using Quizinator.ViewModels.Quiz;

namespace Quizinator.Views.Quiz;

public partial class QuizResultsView : ReactiveUserControl<QuizResultsViewModel>
{
    public QuizResultsView() 
        => InitializeComponent();
}