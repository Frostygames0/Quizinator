using Avalonia.ReactiveUI;
using Quizinator.ViewModels.Quiz;

namespace Quizinator.Views.Quiz;

public partial class QuestionView : ReactiveUserControl<QuestionViewModel>
{
    public QuestionView() 
        => InitializeComponent();
}