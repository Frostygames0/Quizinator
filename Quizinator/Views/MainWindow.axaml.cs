using Avalonia.ReactiveUI;
using Quizinator.ViewModels;
using ReactiveUI;

namespace Quizinator.Views;

public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
{
    public MainWindow()
    {
        this.WhenActivated(disposables => { });
        InitializeComponent();
    }
}