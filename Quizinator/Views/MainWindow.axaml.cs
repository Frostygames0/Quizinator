using System.Threading.Tasks;
using Avalonia.ReactiveUI;
using Quizinator.ViewModels;
using ReactiveUI;

namespace Quizinator.Views;

public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
{
    public MainWindow()
    {
        this.WhenActivated(d => d(ViewModel!.ShowCreatingDialog.RegisterHandler(ShowCreationDialogAsync)));
        InitializeComponent();
    }
    
    private async Task ShowCreationDialogAsync(InteractionContext<CreateQuizViewModel, string?> interaction)
    {
        var dialog = new CreateQuizWindow
        {
            DataContext = interaction.Input
        };
        
        var result = await dialog.ShowDialog<string>(this);
        interaction.SetOutput(result);
    }
}