using Avalonia.ReactiveUI;
using Quizinator.ViewModels.Quiz;
using ReactiveUI;

namespace Quizinator.Views.Quiz;

public partial class QuizView : ReactiveUserControl<QuizViewModel>
{
    public QuizView()
    {
        this.WhenActivated(disposables => { });
        InitializeComponent();
    }
}