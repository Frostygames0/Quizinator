using System.Reflection;
using Quizinator.Extensions;
using Quizinator.Models.Services.Dialogs;
using Quizinator.Models.Services.Quizzes;
using Quizinator.ViewModels;
using Quizinator.ViewModels.Dialogs.Quizzes.Factory;
using Quizinator.Views.Providers;
using ReactiveUI;
using Splat;

namespace Quizinator;

public static class Bootstrapper
{
    public static void Bootstrap(IMutableDependencyResolver mutable, IReadonlyDependencyResolver immutable)
    {
        RegisterServices(mutable, immutable);
        RegisterViews(mutable);
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

        mutable.RegisterLazySingleton(() => new MainMenuViewModel(
                immutable.GetImportantService<ILibraryViewModel>(),
                immutable.GetImportantService<IDialogService>(),
                immutable.GetImportantService<IQuizViewModelFactory>()),
            typeof(IMainMenuViewModel));

        mutable.RegisterLazySingleton(() => new MainWindowViewModel(
                immutable.GetImportantService<IMainMenuViewModel>()),
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