using System;
using Avalonia.ReactiveUI;
using Quizinator.ViewModels.Dialogs;
using ReactiveUI;

namespace Quizinator.Views.Dialogs;

public abstract class DialogWindowBase<T, TResult> : ReactiveWindow<T> where T : DialogViewModelBase<TResult>
{
    protected DialogWindowBase()
    {
        this.WhenActivated(disposables 
            => disposables(ViewModel!.Close.Subscribe(CloseWithResult)));
    }

    private void CloseWithResult(TResult result)
        => Close(result);
}