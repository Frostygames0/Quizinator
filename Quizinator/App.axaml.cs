using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Quizinator.Extensions;
using Quizinator.ViewModels;
using Quizinator.Views;
using Splat;

namespace Quizinator;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow
            {
                DataContext = Locator.Current.GetImportantService<IMainWindowViewModel>()
            };
        }
        
        base.OnFrameworkInitializationCompleted();
    }
}