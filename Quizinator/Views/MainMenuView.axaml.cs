using Avalonia.ReactiveUI;
using Quizinator.ViewModels;

namespace Quizinator.Views;

public partial class MainMenuView : ReactiveUserControl<MainMenuViewModel>
{
    public MainMenuView()
        => InitializeComponent();
    
}