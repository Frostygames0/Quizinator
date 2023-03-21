using Avalonia.ReactiveUI;
using Quizinator.ViewModels.Quizzes;

namespace Quizinator.Views.Quiz;

public partial class QuestionView : ReactiveUserControl<QuestionViewModel>
{
    public QuestionView() 
        => InitializeComponent();
}