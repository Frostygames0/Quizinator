using System.ComponentModel;
using System.Reactive;
using ReactiveUI;

namespace Quizinator.ViewModels;

// TODO Prototype (WILL NOT FINISH UNTIL IMPLEMENT JSON)
public class CreateQuizViewModel : ViewModelBase
{
    private string? _testText;

    public string? TestText
    {
        get => _testText;
        set => this.RaiseAndSetIfChanged(ref _testText, value);
    }

    public ReactiveCommand<Unit, string?> FinalizeCreation { get; }

    public CreateQuizViewModel()
    {
        FinalizeCreation = ReactiveCommand.Create(() => TestText);
    }
}