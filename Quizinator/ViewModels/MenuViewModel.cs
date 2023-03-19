using System;
using System.Reactive;
using Quizinator.Extensions;
using Quizinator.Models.Dialog;
using Quizinator.ViewModels.Dialogs;
using ReactiveUI;
using Splat;

namespace Quizinator.ViewModels;

[Obsolete("Merged into MainMenuViewModel")]
public class MenuViewModel : ViewModelBase, IRoutableViewModel, IActivatableViewModel
{
    private readonly IDialogDisplayer _dialogDisplayer;
    
    public ViewModelActivator Activator { get; }
    
    public ReactiveCommand<Unit, Unit> NewQuiz { get; }
    public ReactiveCommand<Unit, IRoutableViewModel> OpenLibrary { get; }
    
    public string? UrlPathSegment { get; }
    public IScreen HostScreen { get; }

    public MenuViewModel(IScreen hostScreen, IDialogDisplayer? dialogDisplayer = null)
    {
        Activator = new ViewModelActivator();
        
        HostScreen = hostScreen;
        UrlPathSegment = "menu";

        _dialogDisplayer = dialogDisplayer ?? Locator.Current.GetImportantService<IDialogDisplayer>();

        NewQuiz = ReactiveCommand.CreateFromTask(async () =>
        {
            var result =
                await _dialogDisplayer.ShowDialogAsync<CreateQuizDialogViewModel, string>(
                    new CreateQuizDialogViewModel());
            // TODO Do something after this lol
        });

        OpenLibrary = ReactiveCommand.CreateFromObservable(
            () => hostScreen.Router.Navigate.Execute(new LibraryViewModel(hostScreen)));
    }
}