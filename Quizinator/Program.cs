using System;
using Avalonia;
using Avalonia.ReactiveUI;
using Splat;

namespace Quizinator;

class Program
{
    [STAThread]
    public static void Main(string[] args)
    {
        Directories.CreateApplicationDirectories();
        Bootstrapper.Bootstrap(Locator.CurrentMutable);

        BuildAvaloniaApp()
            .StartWithClassicDesktopLifetime(args);
    }
    
    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .LogToTrace()
            .UseReactiveUI();
    
}