using ReactiveUI;

namespace Quizinator.ViewModels;

public class MainWindowViewModel : ViewModelBase, IScreen
{
    public RoutingState Router { get; } = new();

    public Interaction<CreateQuizViewModel, string?> ShowCreatingDialog { get; }

    public MainWindowViewModel()
    {
        ShowCreatingDialog = new Interaction<CreateQuizViewModel, string?>();
        
        Router.Navigate.Execute(new MenuViewModel(this));
    }
}