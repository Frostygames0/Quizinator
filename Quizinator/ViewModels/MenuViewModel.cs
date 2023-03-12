using System.Reactive;
using System.Reactive.Linq;
using ReactiveUI;

namespace Quizinator.ViewModels;

public class MenuViewModel : ViewModelBase, IRoutableViewModel, IActivatableViewModel
{
    public ViewModelActivator Activator { get; }
    
    public ReactiveCommand<Unit, Unit> CreateNewQuiz { get; }
    public ReactiveCommand<Unit, IRoutableViewModel> OpenQuizLibrary { get; }
    
    public string? UrlPathSegment { get; }
    public IScreen HostScreen { get; }

    public MenuViewModel(IScreen hostScreen, Interaction<CreateQuizViewModel, string?> openDialog) // TODO UGH I HATE OPEN DIALOG
    {
        Activator = new ViewModelActivator();
        
        HostScreen = hostScreen;
        UrlPathSegment = "menu";

        CreateNewQuiz = ReactiveCommand.CreateFromTask(async () =>
        {
            var createQuiz = new CreateQuizViewModel();
            var result = await openDialog.Handle(createQuiz);
        });

        OpenQuizLibrary = ReactiveCommand.CreateFromObservable(
            () => hostScreen.Router.Navigate.Execute(new QuizLibraryViewModel(hostScreen, openDialog)));
    }
}