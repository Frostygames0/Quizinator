using System;
using Avalonia.ReactiveUI;
using Quizinator.ViewModels;
using ReactiveUI;

namespace Quizinator.Views;

public partial class CreateQuizWindow : ReactiveWindow<CreateQuizViewModel>
{
    public CreateQuizWindow()
    {
        this.WhenActivated(disposables => disposables(ViewModel!.FinalizeCreation.Subscribe(Close)));
        InitializeComponent();
    }
}