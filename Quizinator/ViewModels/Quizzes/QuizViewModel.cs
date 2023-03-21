using System.Collections.Generic;
using System.Reactive.Disposables;
using System.Windows.Input;
using Quizinator.Models.Quizzes;
using Quizinator.ViewModels.Quizzes.Factory;
using ReactiveUI;

namespace Quizinator.ViewModels.Quizzes;

public class QuizViewModel : ViewModelBase, IQuizViewModel, IActivatableViewModel
{
    private readonly Quiz _quiz;
    private readonly Queue<IQuestionViewModel> _questionViewModels;

    private readonly IRoutableViewModel _viewModelToReturn;

    public ICommand Next { get; }

    public ViewModelActivator Activator { get; } = new();
    public RoutingState Router { get; } = new();
    
    public string? UrlPathSegment { get; }
    public IScreen HostScreen { get; }
    
    public QuizViewModel(IScreen hostScreen, Quiz quiz, IRoutableViewModel viewModelToReturn, 
        IQuizIntroViewModelFactory quizIntroFactory, IQuizResultsViewModelFactory quizResultsFactory,
        IQuestionViewModelFactory questionFactory)
    {
        _quiz = quiz;
        
        HostScreen = hostScreen;
        UrlPathSegment = "quiz";

        _viewModelToReturn = viewModelToReturn;

        _questionViewModels = new Queue<IQuestionViewModel>();
        foreach (var question in _quiz.Questions)
        {
            _questionViewModels.Enqueue(questionFactory.Create(this, question));
        }

        Next = ReactiveCommand.CreateFromObservable(() =>
        {
            if (_questionViewModels.Count == 0)
                return hostScreen.Router.NavigateAndReset.Execute(quizResultsFactory.Create(HostScreen, _quiz, _viewModelToReturn));

            return Router.NavigateAndReset.Execute(_questionViewModels.Dequeue());
        });
        
        this.WhenActivated((CompositeDisposable disposable) 
            => Router.Navigate.Execute(quizIntroFactory.Create(this, _quiz)));
    }
}