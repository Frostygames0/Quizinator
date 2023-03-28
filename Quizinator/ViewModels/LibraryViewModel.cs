using System;
using System.Collections.ObjectModel;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using DynamicData;
using Quizinator.Models.Quizzes;
using Quizinator.Models.Services.Dialogs;
using Quizinator.Models.Services.Quizzes;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace Quizinator.ViewModels;

public class LibraryViewModel : ViewModelBase, ILibraryViewModel, IActivatableViewModel
{
    private readonly IQuizSearcherService _quizSearcherService;
    private readonly ISystemDialogService _systemDialogService;
    
    private readonly ReadOnlyObservableCollection<Quiz> _foundQuizzes;
    
    [Reactive] public string? SearchFolder { get; set; }
    [Reactive] public Quiz? SelectedQuiz { get; set; }
    
    public ReadOnlyObservableCollection<Quiz> FoundQuizzes => _foundQuizzes;
    
    public ICommand RefreshSearch { get; }
    public ICommand OpenSearchFolder { get; }

    public ViewModelActivator Activator { get; } = new();

    public LibraryViewModel(string defaultSearchFolder, IQuizSearcherService quizSearcherService, ISystemDialogService systemDialogService)
    {
        _quizSearcherService = quizSearcherService;
        _systemDialogService = systemDialogService;
        
        SearchFolder = defaultSearchFolder;

        _quizSearcherService.Connect()
            .ObserveOn(RxApp.MainThreadScheduler)
            .Bind(out _foundQuizzes)
            .Subscribe();

        RefreshSearch = ReactiveCommand.CreateFromTask(() => _quizSearcherService.RefreshSearchAsync(SearchFolder));
        OpenSearchFolder = ReactiveCommand.CreateFromTask(OpenFolder);
        
        this.WhenActivated((CompositeDisposable disposable) => RefreshSearch.Execute(null));
    }
    
    private async Task OpenFolder()
    {
        var folder = await _systemDialogService.OpenFolder(SearchFolder);
        if (folder != null)
        {
            SearchFolder = folder;
            RefreshSearch.Execute(null);
        }
    }
}