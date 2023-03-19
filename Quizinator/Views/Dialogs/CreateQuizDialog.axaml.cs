using Quizinator.ViewModels.Dialogs;

namespace Quizinator.Views.Dialogs;

public partial class CreateQuizDialog : DialogWindowBase<CreateQuizDialogViewModel, string>
{
    public CreateQuizDialog()
        => InitializeComponent();
}