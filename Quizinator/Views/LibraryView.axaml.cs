using System;
using Avalonia.ReactiveUI;
using Quizinator.ViewModels;

namespace Quizinator.Views;

[Obsolete("Merged into MainMenuView")]
public partial class LibraryView : ReactiveUserControl<LibraryViewModel>
{
    public LibraryView()
        => InitializeComponent();
}