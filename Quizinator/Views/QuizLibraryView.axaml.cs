using Avalonia.ReactiveUI;
using Quizinator.ViewModels;
using ReactiveUI;

namespace Quizinator.Views;

public partial class QuizLibraryView : ReactiveUserControl<QuizLibraryViewModel>
{
    public QuizLibraryView()
    {
        this.WhenActivated(disposables => { });
        InitializeComponent();
    }
}