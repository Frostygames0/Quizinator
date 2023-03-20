using Avalonia.ReactiveUI;
using Quizinator.ViewModels;

namespace Quizinator.Views;

public partial class LibraryView : ReactiveUserControl<ILibraryViewModel>
{
    public LibraryView()
        => InitializeComponent();
}