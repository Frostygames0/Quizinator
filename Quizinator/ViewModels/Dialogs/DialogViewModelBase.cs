using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace Quizinator.ViewModels.Dialogs;

public abstract class DialogViewModelBase<TResult> : ViewModelBase
{
    private readonly ISubject<TResult> _requestedClosing = new Subject<TResult>();

    public IObservable<TResult> RequestedClosing => _requestedClosing.AsObservable();

    protected void Close(TResult result)
    {
        _requestedClosing.OnNext(result);
        _requestedClosing.OnCompleted();
    }
}

public abstract class DialogViewModelBase : DialogViewModelBase<object>
{
    protected void Close()
        => Close(null);
}