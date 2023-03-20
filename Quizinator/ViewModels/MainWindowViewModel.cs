using System.Reactive.Disposables;
using Quizinator.ViewModels.Factory;
using ReactiveUI;

namespace Quizinator.ViewModels;

public class MainWindowViewModel : ViewModelBase, IMainWindowViewModel
{
    private readonly IMainMenuViewModel _mainMenuViewModel;
    
    public ViewModelActivator Activator { get; } = new();
    public RoutingState Router { get; } = new();

    public MainWindowViewModel(IMainMenuViewModelFactory mainMenuViewModelFactory)
    {
        _mainMenuViewModel = mainMenuViewModelFactory.Create(this);
        
        this.WhenActivated((CompositeDisposable disposable) 
            => Router.Navigate.Execute(_mainMenuViewModel));
    }
}