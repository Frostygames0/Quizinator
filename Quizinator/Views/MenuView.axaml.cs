using Avalonia.ReactiveUI;
using Quizinator.ViewModels;
using ReactiveUI;

namespace Quizinator.Views;

public partial class MenuView : ReactiveUserControl<MenuViewModel>
{
    public MenuView()
    {
        this.WhenActivated(disposables => {});
        InitializeComponent();
    }
}