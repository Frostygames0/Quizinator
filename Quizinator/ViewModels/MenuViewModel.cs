using System.Reactive;
using Quizinator.Models.Dialog;
using Quizinator.ViewModels.Dialogs;
using ReactiveUI;
using Splat;

namespace Quizinator.ViewModels;

public class MenuViewModel : ViewModelBase, IRoutableViewModel, IActivatableViewModel
{
    private readonly IDialogDisplayer? _dialogDisplayer;
    
    public ViewModelActivator Activator { get; }
    
    public ReactiveCommand<Unit, Unit> CreateNewQuiz { get; }
    public ReactiveCommand<Unit, IRoutableViewModel> OpenQuizLibrary { get; }
    
    public string? UrlPathSegment { get; }
    public IScreen HostScreen { get; }

    public MenuViewModel(IScreen hostScreen, IDialogDisplayer? dialogDisplayer = null)
    {
        Activator = new ViewModelActivator();
        
        HostScreen = hostScreen;
        UrlPathSegment = "menu";

        _dialogDisplayer = dialogDisplayer ?? Locator.Current.GetService<IDialogDisplayer>();

        CreateNewQuiz = ReactiveCommand.CreateFromTask(async () =>
        {
            var result = await _dialogDisplayer.ShowDialogAsync<CreateQuizDialogViewModel, string>(new CreateQuizDialogViewModel());
        });

        OpenQuizLibrary = ReactiveCommand.CreateFromObservable(
            () => hostScreen.Router.Navigate.Execute(new LibraryViewModel(hostScreen)));
    }
}