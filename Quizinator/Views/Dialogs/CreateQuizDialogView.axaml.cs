using System;
using Quizinator.ViewModels.Dialogs;
using ReactiveUI;

namespace Quizinator.Views.Dialogs;

public partial class CreateQuizDialogView : DialogWindowBase<CreateQuizDialogViewModel, string>
{
    public CreateQuizDialogView()
    {
        this.WhenActivated(disposables => disposables(ViewModel!.FinalizeCreation.Subscribe(Close)));
        InitializeComponent();
    }
}