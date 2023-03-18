using System.Reactive;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace Quizinator.ViewModels.Dialogs;

// TODO Prototype (WILL NOT FINISH UNTIL IMPLEMENT JSON)
public class CreateQuizDialogViewModel : DialogViewModelBase<string>
{
    [Reactive] 
    public string? TestText { get; set; }

    public ReactiveCommand<Unit, string?> FinalizeCreation { get; }

    public CreateQuizDialogViewModel()
    {
        FinalizeCreation = ReactiveCommand.Create(() => TestText);
    }
}