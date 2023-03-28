using System.Collections.Generic;
using System.Reactive.Disposables;
using System.Windows.Input;
using Quizinator.Models.Quizzes;
using Quizinator.ViewModels.Dialogs.Quizzes.Factory;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace Quizinator.ViewModels.Dialogs.Quizzes;

public class QuizDialogViewModel : DialogViewModelBase, IQuizDialogViewModel, IActivatableViewModel
{
    private readonly Quiz _quiz;
    private readonly Queue<IQuestionViewModel> _questionViewModels;

    [Reactive] public bool ReachedEnd { get; set; }
    
    public ICommand Next { get; }

    public ViewModelActivator Activator { get; } = new();
    public RoutingState Router { get; } = new();

    public QuizDialogViewModel(Quiz quiz, 
        IQuizIntroViewModelFactory quizIntroFactory, 
        IQuizResultsViewModelFactory quizResultsFactory,
        IQuestionViewModelFactory questionFactory)
    {
        _quiz = quiz;
        _questionViewModels = new Queue<IQuestionViewModel>();
        foreach (var question in _quiz.Questions)
        {
            _questionViewModels.Enqueue(questionFactory.Create(this, question));
        }

        Next = ReactiveCommand.CreateFromObservable(() =>
        {
            if (_questionViewModels.Count == 0)
                return Router.NavigateAndReset.Execute(quizResultsFactory.Create(this, _quiz));

            return Router.NavigateAndReset.Execute(_questionViewModels.Dequeue());
        });

        this.WhenActivated((CompositeDisposable disposable) 
            => Router.Navigate.Execute(quizIntroFactory.Create(this, _quiz)));
    }
}