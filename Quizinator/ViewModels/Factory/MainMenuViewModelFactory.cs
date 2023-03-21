using Quizinator.Models.Services.Dialogs;
using Quizinator.ViewModels.Quizzes.Factory;
using ReactiveUI;

namespace Quizinator.ViewModels.Factory;

public class MainMenuViewModelFactory : IMainMenuViewModelFactory
{
    private readonly ILibraryViewModel _libraryViewModel;
    private readonly IDialogService _dialogService;

    private readonly IQuizViewModelFactory _quizViewFactory;

    public MainMenuViewModelFactory(ILibraryViewModel libraryViewModel, IDialogService dialogService,
        IQuizViewModelFactory quizViewFactory)
    {
        _libraryViewModel = libraryViewModel;
        _dialogService = dialogService;

        _quizViewFactory = quizViewFactory;
    }
    
    public IMainMenuViewModel Create(IScreen hostScreen)
    {
        return new MainMenuViewModel(hostScreen, _libraryViewModel, _dialogService, _quizViewFactory);
    }
}