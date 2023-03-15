using System.IO;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Quizinator.ViewModels;
using Quizinator.Views;

namespace Quizinator;

public partial class App : Application
{
    public override void Initialize()
    {
        Directory.CreateDirectory(Paths.Quizzes); // TODO Move to a bootstrapper of sort
        
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow
            {
                DataContext = new MainWindowViewModel()
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}