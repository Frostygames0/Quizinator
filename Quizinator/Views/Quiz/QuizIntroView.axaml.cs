using Avalonia.ReactiveUI;
using Quizinator.ViewModels.Quiz;

namespace Quizinator.Views.Quiz;

public partial class QuizIntroView : ReactiveUserControl<QuizIntroViewModel>
{
    public QuizIntroView()
        => InitializeComponent();
}