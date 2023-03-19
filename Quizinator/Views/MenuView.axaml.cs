using System;
using Avalonia.ReactiveUI;
using Quizinator.ViewModels;

namespace Quizinator.Views;

[Obsolete("Merged into MainMenuView")]
public partial class MenuView : ReactiveUserControl<MenuViewModel>
{
    public MenuView() 
        => InitializeComponent();
}