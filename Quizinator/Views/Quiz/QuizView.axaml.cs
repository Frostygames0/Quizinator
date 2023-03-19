using Avalonia.ReactiveUI;
using Quizinator.ViewModels.Quiz;

namespace Quizinator.Views.Quiz;

public partial class QuizView : ReactiveUserControl<QuizViewModel>
{
    public QuizView() 
        => InitializeComponent();
}