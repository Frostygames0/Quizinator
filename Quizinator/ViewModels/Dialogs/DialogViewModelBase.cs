using ReactiveUI;

namespace Quizinator.ViewModels.Dialogs;

public abstract class DialogViewModelBase<TResult> : ViewModelBase
{
    public ReactiveCommand<TResult, TResult> Close { get; }

    protected DialogViewModelBase()
    {
        /*Close = ReactiveCommand.Create(input =>
        {
            return input;
        });*/
    }

    protected void CloseDialog(TResult result)
    {
        Close.Execute();
    }
}