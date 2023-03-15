using Avalonia.ReactiveUI;
using Quizinator.ViewModels;
using ReactiveUI;

namespace Quizinator.Views.Quiz;

public partial class QuizResultsView : ReactiveUserControl<QuizResultsViewModel>
{
    public QuizResultsView()
    {
        this.WhenActivated(disposables => { });
        InitializeComponent();
    }
}