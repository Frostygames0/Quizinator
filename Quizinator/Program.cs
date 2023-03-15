using System;
using System.Reflection;
using Avalonia;
using Avalonia.ReactiveUI;
using ReactiveUI;
using Splat;

namespace Quizinator;

class Program
{
    [STAThread]
    public static void Main(string[] args)
    {
        // Honestly, I still have no idea why registration is this early? But it works! works fine at least!
        Locator.CurrentMutable.RegisterViewsForViewModels(Assembly.GetCallingAssembly());
        
        BuildAvaloniaApp()
            .StartWithClassicDesktopLifetime(args);
    }
    
    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .LogToTrace()
            .UseReactiveUI();
}