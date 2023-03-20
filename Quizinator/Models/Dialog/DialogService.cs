using System;
using System.Threading.Tasks;
using Quizinator.ViewModels.Dialogs;
using Quizinator.Views.Dialogs;
using Quizinator.Views.Providers;
using ReactiveUI;

namespace Quizinator.Models.Dialog;

public class DialogService : IDialogService
{
    private readonly IMainWindowProvider _provider;
    private readonly IViewLocator _viewLocator;
    
    public DialogService(IMainWindowProvider provider, IViewLocator viewLocator)
    {
        _provider = provider;
        _viewLocator = viewLocator;
    }
    
    public Task<TResult> ShowDialogAsync<T, TResult>(T dialogViewModel) where T : DialogViewModelBase<TResult>
    {
        if (_viewLocator.ResolveView(dialogViewModel) is not DialogWindowBase<T, TResult> view)
            throw new InvalidOperationException("View for view model is not a dialog!");

        view.DataContext = dialogViewModel;
        
        var mainWindow = _provider.ProvideMainWindow();
        return view.ShowDialog<TResult>(mainWindow);
    }
}