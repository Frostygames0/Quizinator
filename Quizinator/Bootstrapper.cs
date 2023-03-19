using System.Reflection;
using Quizinator.Models;
using Quizinator.Models.Dialog;
using Quizinator.Views.Providers;
using ReactiveUI;
using Splat;

namespace Quizinator;

public static class Bootstrapper
{
    public static void Bootstrap(IMutableDependencyResolver mutable)
    {
        RegisterViews(mutable);
        RegisterServices(mutable);
    }

    private static void RegisterViews(IMutableDependencyResolver mutable)
    {
        mutable.RegisterViewsForViewModels(Assembly.GetEntryAssembly());
    }

    private static void RegisterServices(IMutableDependencyResolver mutable)
    {
        mutable.RegisterLazySingleton(() => new MainWindowProvider(), typeof(IMainWindowProvider));
        mutable.RegisterLazySingleton(() => new SystemDialogDisplayer(), typeof(ISystemDialogDisplayer));
        mutable.RegisterLazySingleton(() => new DialogDisplayer(), typeof(IDialogDisplayer));
        mutable.RegisterLazySingleton(() => new QuizSearcher(Directories.Quizzes), typeof(IQuizSearcher));
    }
}