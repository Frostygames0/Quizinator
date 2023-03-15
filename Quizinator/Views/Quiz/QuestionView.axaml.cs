using Avalonia.ReactiveUI;
using Quizinator.ViewModels;
using ReactiveUI;

namespace Quizinator.Views.Quiz;

public partial class QuestionView : ReactiveUserControl<QuestionViewModel>
{
    public QuestionView()
    {
        this.WhenActivated(disposables => { });
        InitializeComponent();
    }
}