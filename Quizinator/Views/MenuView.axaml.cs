using Avalonia.ReactiveUI;
using Quizinator.ViewModels;

namespace Quizinator.Views;

public partial class MenuView : ReactiveUserControl<MenuViewModel>
{
    public MenuView() 
        => InitializeComponent();
}