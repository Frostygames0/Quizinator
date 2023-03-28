using System;
using System.Threading.Tasks;
using Avalonia.Controls;
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
    
    public async Task<TResult> ShowDialogAsync<TResult>(DialogViewModelBase<TResult> dialogViewModel)
    {
        if (_viewLocator.ResolveView(dialogViewModel) is not Window window)
            throw new InvalidOperationException("View for view model is not a window!");

        window.DataContext = dialogViewModel;
        
        var mainWindow = _provider.ProvideMainWindow();
        return await window.ShowDialog<TResult>(mainWindow);
    }
    
    public async Task ShowDialogAsync(DialogViewModelBase dialogViewModel)
        => await ShowDialogAsync<object>(dialogViewModel);
}