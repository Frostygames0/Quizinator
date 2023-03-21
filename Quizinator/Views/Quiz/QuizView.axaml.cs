using Avalonia.ReactiveUI;
using Quizinator.ViewModels.Quizzes;

namespace Quizinator.Views.Quiz;

public partial class QuizView : ReactiveUserControl<QuizViewModel>
{
    public QuizView() 
        => InitializeComponent();
}