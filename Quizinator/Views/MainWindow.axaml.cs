using Avalonia.ReactiveUI;
using Quizinator.ViewModels;

namespace Quizinator.Views;

public partial class MainWindow : ReactiveWindow<IMainWindowViewModel>
{
    public MainWindow() 
        => InitializeComponent();
}