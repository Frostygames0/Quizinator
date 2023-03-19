using System;
using System.Threading.Tasks;
using Quizinator.Extensions;
using Quizinator.ViewModels.Dialogs;
using Quizinator.Views.Dialogs;
using Quizinator.Views.Providers;
using ReactiveUI;
using Splat;

namespace Quizinator.Models.Dialog;

public class DialogDisplayer : IDialogDisplayer
{
    private readonly IMainWindowProvider _provider;
    private readonly IViewLocator _viewLocator;
    
    public DialogDisplayer(IMainWindowProvider? provider = null, IViewLocator? viewLocator = null)
    {
        _provider = provider ?? Locator.Current.GetImportantService<IMainWindowProvider>();
        _viewLocator = viewLocator ?? ViewLocator.Current;
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