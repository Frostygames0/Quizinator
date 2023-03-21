using System;
using System.Threading.Tasks;
using Avalonia.ReactiveUI;
using Quizinator.ViewModels.Dialogs;
using Quizinator.Views.Providers;
using ReactiveUI;

namespace Quizinator.Models.Services.Dialogs;

public class DialogService : IDialogService
{
    private readonly IMainWindowProvider _provider;
    private readonly IViewLocator _viewLocator;
    
    public DialogService(IMainWindowProvider provider, IViewLocator viewLocator)
    {
        _provider = provider;
        _viewLocator = viewLocator;
    }
    
    public async Task<TResult> ShowDialogAsync<T, TResult>(T dialogViewModel) where T : DialogViewModelBase<TResult>
    {
        if (_viewLocator.ResolveView(dialogViewModel) is not ReactiveWindow<T> view)
            throw new InvalidOperationException("View for view model is not a window!");

        view.ViewModel = dialogViewModel;
        
        var mainWindow = _provider.ProvideMainWindow();
        return await view.ShowDialog<TResult>(mainWindow);
    }
    
    // Overload for dialogs that return nothing
    public async Task ShowDialogAsync<T>(T dialogViewModel) where T : DialogViewModelBase
        => await ShowDialogAsync<T, object>(dialogViewModel);
}