using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;

namespace Quizinator.Views.Providers;

public class MainWindowProvider : IMainWindowProvider
{
    public Window ProvideMainWindow()
    {
        if (Application.Current.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime lifetime)
            return lifetime.MainWindow;
        
        throw new InvalidOperationException("No main window is found. Probably called too early or a different application lifetime is set");
    }
}