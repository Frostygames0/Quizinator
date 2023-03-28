using System;
using Avalonia.ReactiveUI;
using Quizinator.ViewModels.Dialogs;
using ReactiveUI;

namespace Quizinator.Views.Dialogs;

public abstract class DialogWindowBase<T, TResult> : ReactiveWindow<T> where T : DialogViewModelBase<TResult>
{
    protected DialogWindowBase()
    {
        this.WhenActivated(disposables =>
            disposables(ViewModel!.RequestedClosing.Subscribe(OnViewModelRequestedClosing)));
    }

    private void OnViewModelRequestedClosing(TResult result) 
        => Close(result);
}

public abstract class DialogWindowBase<T> : DialogWindowBase<T, object> where T : DialogViewModelBase
{
    
}