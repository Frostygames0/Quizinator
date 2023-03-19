using Avalonia.Controls;

namespace Quizinator.Views.Providers;

public interface IMainWindowProvider
{
    Window ProvideMainWindow();
}