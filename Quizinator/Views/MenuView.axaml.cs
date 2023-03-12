using System;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.ReactiveUI;
using Quizinator.ViewModels;
using ReactiveUI;

namespace Quizinator.Views;

public partial class MenuView : ReactiveUserControl<MenuViewModel>
{
    public MenuView()
    {
        this.WhenActivated(d => {});
        InitializeComponent();
    }
    
    private async Task ShowCreationDialogAsync(InteractionContext<CreateQuizViewModel, string?> interaction)
    {
        var dialog = new CreateQuizWindow
        {
            DataContext = interaction.Input
        };

        var supposedWindow = ViewModel!.HostScreen as Window;
        if (supposedWindow is null)
        {
            if (Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime lifetime)
                lifetime.Shutdown();
        }
        var result = await dialog.ShowDialog<string>(supposedWindow);
        interaction.SetOutput(result);
    }
}