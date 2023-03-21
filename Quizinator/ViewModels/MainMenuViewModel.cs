using System.Reactive.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Quizinator.Models.Services.Dialogs;
using Quizinator.ViewModels.Dialogs;
using Quizinator.ViewModels.Quizzes.Factory;
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

        var canBeginQuiz = 
            this.WhenAnyValue(x => x.LibraryViewModel.SelectedQuiz)
                .Select(quiz => quiz is not null);
        BeginQuiz = ReactiveCommand.CreateFromObservable(() => 
            HostScreen.Router.NavigateAndReset.Execute(quizViewFactory.Create(hostScreen, LibraryViewModel.SelectedQuiz, this)), canBeginQuiz);
        NewQuiz = ReactiveCommand.CreateFromTask(CreateNewQuiz);
        OpenSettings = ReactiveCommand.CreateFromTask(OpenSettingsMenu);
    }

    private async Task CreateNewQuiz()
    {
        var result = await _dialogService.ShowDialogAsync<CreateQuizDialogViewModel, string>(new CreateQuizDialogViewModel());
        // TODO Implement quiz creation
    }

    private async Task OpenSettingsMenu()
    {
        // TODO Implement settings behaviour
    }
}