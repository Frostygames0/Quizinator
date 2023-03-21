using System.Collections.ObjectModel;
using System.Reactive.Disposables;
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
    
    [Reactive] public string? SearchFolder { get; set; }
    [Reactive] public Quiz? SelectedQuiz { get; set; }
    
    public ObservableCollection<Quiz> FoundQuizzes { get; }
    
    public ICommand RefreshSearch { get; }
    public ICommand OpenSearchFolder { get; }

    public ViewModelActivator Activator { get; } = new();

    public LibraryViewModel(string defaultSearchFolder, IQuizSearcherService quizSearcherService, ISystemDialogService systemDialogService)
    {
        _quizSearcherService = quizSearcherService;
        _systemDialogService = systemDialogService;

        FoundQuizzes = new ObservableCollection<Quiz>();
        SearchFolder = defaultSearchFolder;

        RefreshSearch = ReactiveCommand.CreateFromTask(RefreshFoundQuizzes);
        OpenSearchFolder = ReactiveCommand.CreateFromTask(OpenFolder);
        
        this.WhenActivated((CompositeDisposable disposable) => RefreshSearch.Execute(null));
    }
    
    private async Task RefreshFoundQuizzes()
    {
        bool updated = await _quizSearcherService.TrySearch(SearchFolder);
        if (!updated) 
            return;
            
        FoundQuizzes.Clear();
        FoundQuizzes.AddRange(_quizSearcherService.FoundQuizzes);
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