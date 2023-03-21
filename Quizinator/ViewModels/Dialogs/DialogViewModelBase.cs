using System;

namespace Quizinator.ViewModels.Dialogs;

public abstract class DialogViewModelBase<TResult> : ViewModelBase
{
    public event EventHandler<DialogResultEventArgs<TResult>> RequestedClosing;
    
    protected void Close(TResult result)
    {
        var args = new DialogResultEventArgs<TResult>(result);
        RequestedClosing?.Invoke(this, args);
    }
}

public abstract class DialogViewModelBase : DialogViewModelBase<object>
{
    protected void Close()
        => Close(null);
}

public class DialogResultEventArgs<TResult> : EventArgs
{
    public TResult Result { get; }

    public DialogResultEventArgs(TResult result)
        => Result = result;
}