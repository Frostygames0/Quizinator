using System.Collections.Generic;
using System.Reactive;
using ReactiveUI;

namespace Quizinator.ViewModels.Quiz;

public class QuizViewModel : ViewModelBase, IScreen, IRoutableViewModel, IActivatableViewModel
{
    private readonly Models.Quiz _quiz;
    private readonly Queue<QuestionViewModel> _questionViewModels;

    public ReactiveCommand<Unit, IRoutableViewModel> Next { get; }

    public ViewModelActivator Activator { get; } = new();
    public RoutingState Router { get; } = new();
    public string? UrlPathSegment { get; }
    public IScreen HostScreen { get; }
    
    public QuizViewModel(IScreen hostScreen, Models.Quiz quiz)
    {
        _quiz = quiz;
        
        HostScreen = hostScreen;
        UrlPathSegment = "quiz";

        _questionViewModels = new Queue<QuestionViewModel>();
        foreach (var question in _quiz.Questions)
        {
            _questionViewModels.Enqueue(new QuestionViewModel(this, question));
        }

        Next = ReactiveCommand.CreateFromObservable(() =>
        {
            if (_questionViewModels.Count == 0)
            {
                return hostScreen.Router.NavigateAndReset.Execute(new QuizResultsViewModel(hostScreen, _quiz));
            }
            
            return Router.NavigateAndReset.Execute(_questionViewModels.Dequeue());
        });
        
        Router.Navigate.Execute(new QuizIntroViewModel(this, _quiz));
    }
}