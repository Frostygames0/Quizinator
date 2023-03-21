using Avalonia.ReactiveUI;
using Quizinator.ViewModels.Quizzes;

namespace Quizinator.Views.Quiz;

public partial class QuizIntroView : ReactiveUserControl<QuizIntroViewModel>
{
    public QuizIntroView()
        => InitializeComponent();
}