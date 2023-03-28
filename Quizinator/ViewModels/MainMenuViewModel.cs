using System.Reactive.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Quizinator.Models.Services.Dialogs;
using Quizinator.ViewModels.Dialogs;
using Quizinator.ViewModels.Dialogs.Quizzes.Factory;
using ReactiveUI;

namespace Quizinator.ViewModels;

public class MainMenuViewModel : ViewModelBase, IMainMenuViewModel
{
    private readonly IDialogService _dialogService;
    
    public ILibraryViewModel LibraryViewModel { get; }

    public ICommand NewQuiz { get; }
    public ICommand BeginQuiz { get; }
    public ICommand OpenSettings { get; }

    public MainMenuViewModel(ILibraryViewModel libraryViewModel, IDialogService dialogService, IQuizViewModelFactory quizViewFactory)
    {
        LibraryViewModel = libraryViewModel;
        _dialogService = dialogService;

        var canBeginQuiz = 
            this.WhenAnyValue(x => x.LibraryViewModel.SelectedQuiz)
                .Select(quiz => quiz is not null);
        BeginQuiz = ReactiveCommand.CreateFromTask(async () =>
        {
            var quizViewModel = quizViewFactory.Create(LibraryViewModel.SelectedQuiz);
            if (quizViewModel is DialogViewModelBase dialog) // TODO Dunno why, but I don't like it
                await _dialogService.ShowDialogAsync(dialog);
        }, canBeginQuiz);
        NewQuiz = ReactiveCommand.CreateFromTask(CreateNewQuiz);
        OpenSettings = ReactiveCommand.CreateFromTask(OpenSettingsMenu);
    }
    
    private async Task CreateNewQuiz()
    {
        var result = await _dialogService.ShowDialogAsync(new CreateQuizDialogViewModel());
        // TODO Implement quiz creation
    }

    private async Task OpenSettingsMenu()
    {
        // TODO Implement settings behaviour
    }
}