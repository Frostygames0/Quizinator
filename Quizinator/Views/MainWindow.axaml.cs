using Avalonia.ReactiveUI;
using Quizinator.ViewModels;

namespace Quizinator.Views;

public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
{
    public MainWindow() 
        => InitializeComponent();
}