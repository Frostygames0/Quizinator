using Avalonia.ReactiveUI;
using Quizinator.ViewModels;

namespace Quizinator.Views;

public partial class MainMenuView : ReactiveUserControl<IMainMenuViewModel>
{
    public MainMenuView()
        => InitializeComponent();
}