using ReactiveUI;

namespace Quizinator.ViewModels;

public class MainWindowViewModel : ViewModelBase, IScreen, IActivatableViewModel
{
    public ViewModelActivator Activator { get; }
    
    public RoutingState Router { get; }

    public Interaction<CreateQuizViewModel, string?> ShowCreatingDialog { get; }

    public MainWindowViewModel()
    {
        Activator = new ViewModelActivator();
        
        ShowCreatingDialog = new Interaction<CreateQuizViewModel, string?>();

        Router = new RoutingState();
        Router.Navigate.Execute(new MenuViewModel(this, ShowCreatingDialog));
    }
    
    
    
    
}