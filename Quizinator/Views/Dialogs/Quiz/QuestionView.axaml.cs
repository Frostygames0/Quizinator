using Avalonia.ReactiveUI;
using Quizinator.ViewModels.Dialogs.Quizzes;

namespace Quizinator.Views.Dialogs.Quiz;

public partial class QuestionView : ReactiveUserControl<QuestionViewModel>
{
    public QuestionView() 
        => InitializeComponent();
}