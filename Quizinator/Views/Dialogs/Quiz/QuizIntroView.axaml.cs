using Avalonia.ReactiveUI;
using Quizinator.ViewModels.Dialogs.Quizzes;

namespace Quizinator.Views.Dialogs.Quiz;

public partial class QuizIntroView : ReactiveUserControl<QuizIntroViewModel>
{
    public QuizIntroView()
        => InitializeComponent();
}