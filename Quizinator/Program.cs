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
        Directories.CreateAppDirectories();
        Bootstrapper.Bootstrap(Locator.CurrentMutable, Locator.Current);

        BuildAvaloniaApp()
            .StartWithClassicDesktopLifetime(args);
    }
    
    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .LogToTrace()
            .UseReactiveUI();
    
}