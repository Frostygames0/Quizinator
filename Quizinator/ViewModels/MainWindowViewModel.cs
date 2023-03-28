namespace Quizinator.ViewModels;

public class MainWindowViewModel : ViewModelBase, IMainWindowViewModel
{
    private IMainMenuViewModel MainMenuViewModel { get; }

    public MainWindowViewModel(IMainMenuViewModel mainMenuViewModel)
    {
        MainMenuViewModel = mainMenuViewModel;
    }
}