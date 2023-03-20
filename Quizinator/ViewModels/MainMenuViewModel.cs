using System.Threading.Tasks;
using System.Windows.Input;
using Quizinator.Models.Dialog;
using Quizinator.ViewModels.Dialogs;
using Quizinator.ViewModels.Quiz.Factory;
using ReactiveUI;

namespace Quizinator.ViewModels;

public class MainMenuViewModel : ViewModelBase, IMainMenuViewModel
{
    private readonly IDialogService _dialogService;
    
    public ILibraryViewModel LibraryViewModel { get; }

    public ICommand NewQuiz { get; }
    public ICommand BeginQuiz { get; }
    public ICommand OpenSettings { get; }

    public string? UrlPathSegment { get; }
    public IScreen HostScreen { get; }

    public MainMenuViewModel(IScreen hostScreen, ILibraryViewModel libraryViewModel, IDialogService dialogService, IQuizViewModelFactory quizViewFactory)
    {
        HostScreen = hostScreen;
        UrlPathSegment = "quiz_library";

        LibraryViewModel = libraryViewModel;
        _dialogService = dialogService;
        
        NewQuiz = ReactiveCommand.CreateFromTask(CreateNewQuiz);
        BeginQuiz = ReactiveCommand.CreateFromObservable(() => HostScreen.Router.NavigateAndReset.Execute(quizViewFactory.Create(hostScreen, LibraryViewModel.SelectedQuiz, this)));
        OpenSettings = ReactiveCommand.Create(() => {});
    }

    private async Task CreateNewQuiz()
    {
        var result = await _dialogService.ShowDialogAsync<CreateQuizDialogViewModel, string>(new CreateQuizDialogViewModel());
    }
}