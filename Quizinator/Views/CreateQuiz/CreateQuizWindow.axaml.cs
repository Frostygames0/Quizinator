using System;
using Avalonia.ReactiveUI;
using ReactiveUI;
using Quizinator.ViewModels;

namespace Quizinator.Views;

public partial class CreateQuizWindow : ReactiveWindow<CreateQuizViewModel>
{
    public CreateQuizWindow()
    {
        this.WhenActivated(disposables => disposables(ViewModel!.FinalizeCreation.Subscribe(Close)));
        InitializeComponent();
    }
}