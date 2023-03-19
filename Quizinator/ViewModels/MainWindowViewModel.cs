using System.Reactive.Disposables;
using ReactiveUI;

namespace Quizinator.ViewModels;

public class MainWindowViewModel : ViewModelBase, IScreen, IActivatableViewModel
{
    public ViewModelActivator Activator { get; } = new();
    public RoutingState Router { get; } = new();

    public MainWindowViewModel()
    {
        this.WhenActivated((CompositeDisposable disposable) 
            => Router.Navigate.Execute(new MainMenuViewModel(this)));
    }
}