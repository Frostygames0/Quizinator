using System.Reflection;
using Quizinator.Extensions;
using Quizinator.Models;
using Quizinator.Models.Dialog;
using Quizinator.ViewModels;
using Quizinator.ViewModels.Factory;
using Quizinator.ViewModels.Quiz.Factory;
using Quizinator.Views.Providers;
using ReactiveUI;
using Splat;

namespace Quizinator;

public static class Bootstrapper
{
    public static void Bootstrap(IMutableDependencyResolver mutable, IReadonlyDependencyResolver immutable)
    {
        RegisterViews(mutable);
        RegisterServices(mutable, immutable);
        RegisterViewModels(mutable, immutable);
    }

    private static void RegisterViews(IMutableDependencyResolver mutable)
    {
        mutable.RegisterViewsForViewModels(Assembly.GetEntryAssembly());
    }

    private static void RegisterViewModels(IMutableDependencyResolver mutable, IReadonlyDependencyResolver immutable)
    {
        mutable.RegisterLazySingleton(() => new QuizViewModelFactory(
                new QuizIntroViewModelFactory(),
                new QuizResultsViewModelFactory(),
                new QuestionViewModelFactory()),
            typeof(IQuizViewModelFactory));

        mutable.RegisterLazySingleton(() => new LibraryViewModel(Directories.Quizzes,
                immutable.GetImportantService<IQuizSearcherService>(),
                immutable.GetImportantService<ISystemDialogService>()),
            typeof(ILibraryViewModel));

        mutable.RegisterLazySingleton(() => new MainMenuViewModelFactory(
                immutable.GetImportantService<ILibraryViewModel>(),
                immutable.GetImportantService<IDialogService>(),
                immutable.GetImportantService<IQuizViewModelFactory>()),
            typeof(IMainMenuViewModelFactory));

        mutable.RegisterLazySingleton(() => new MainWindowViewModel(
                immutable.GetImportantService<IMainMenuViewModelFactory>()),
            typeof(IMainWindowViewModel));
    }

    private static void RegisterServices(IMutableDependencyResolver mutable, IReadonlyDependencyResolver immutable)
    {
        mutable.RegisterLazySingleton(() => new MainWindowProvider(),
            typeof(IMainWindowProvider));
        mutable.RegisterLazySingleton(() => new SystemDialogService(
                immutable.GetImportantService<IMainWindowProvider>()),
            typeof(ISystemDialogService));
        mutable.RegisterLazySingleton(() => new DialogService(
                immutable.GetImportantService<IMainWindowProvider>(),
                immutable.GetImportantService<IViewLocator>()),
            typeof(IDialogService));
        mutable.RegisterLazySingleton(() => new QuizSearcherService(Directories.Quizzes),
            typeof(IQuizSearcherService));
    }
}