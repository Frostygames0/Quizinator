using System;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Quizinator.ViewModels.Dialogs;
using Quizinator.Views.Dialogs;
using ReactiveUI;

namespace Quizinator.Models.Dialog;

public class DialogDisplayer : IDialogDisplayer
{
    private readonly IViewLocator _viewLocator;
    
    public DialogDisplayer(IViewLocator? viewLocator = null)
    {
        _viewLocator = viewLocator ?? ViewLocator.Current;
    }
    
    public Task<TResult> ShowDialogAsync<T, TResult>(T dialogViewModel) where T : DialogViewModelBase<TResult>
    {
        if (_viewLocator.ResolveView(dialogViewModel) is not DialogWindowBase<T, TResult> view)
            throw new InvalidOperationException("View for dialog view model is not a dialog window!");
        
        var mainWindow = GetMainWindow(); // TODO don't really like this either
        if (mainWindow is null)
            throw new InvalidOperationException("No main window is found. Probably called too early or a different application lifetime is set");
        
        return view.ShowDialog<TResult>(mainWindow);
    }

    private DialogWindowBase<T, TResult> ResolveView<T, TResult>(T dialogViewModel) where T : DialogViewModelBase<TResult>
    {
        var viewName = dialogViewModel.GetType().FullName!.Replace("ViewModel", "View");
        var viewType = Type.GetType(viewName);

        if (viewType is null)
            throw new InvalidOperationException("No view was found for dialog's viewmodel");

        return (DialogWindowBase<T, TResult>) Activator.CreateInstance(viewType)!;
    }
    
    // TODO Replace it with constructor after I figure out
    private Window GetMainWindow()
    {
        if (Application.Current.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime lifetime)
            return lifetime.MainWindow;
        
        throw new InvalidOperationException("It seems that app is still initializing!");
    }
    
}