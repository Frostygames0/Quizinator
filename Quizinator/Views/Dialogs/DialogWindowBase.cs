using System.Reactive.Disposables;
using Avalonia.ReactiveUI;
using Quizinator.ViewModels.Dialogs;
using ReactiveUI;

namespace Quizinator.Views.Dialogs;

public abstract class DialogWindowBase<T, TResult> : ReactiveWindow<T> where T : DialogViewModelBase<TResult>
{
    protected DialogWindowBase()
    {
        this.WhenActivated(disposables =>
        {
            ViewModel!.RequestedClosing += OnViewModelRequestedClosing;

            Disposable.Create(() => ViewModel!.RequestedClosing -= OnViewModelRequestedClosing)
                .DisposeWith(disposables);
        });
    }
    
    private void OnViewModelRequestedClosing(object? sender, DialogResultEventArgs<TResult> eventArgs) 
        => Close(eventArgs.Result);
    
}