using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using Quizinator.Models;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace Quizinator.ViewModels.Quiz;

public class QuestionViewModel : ViewModelBase, IRoutableViewModel
{
    private readonly Question _question;

    [Reactive]
    public int ChosenAnswerIndex { get; set; }

    public string Question => _question.LiteralQuestion;
    public IList<string> Answers => _question.Answers;
    
    public string UrlPathSegment { get; }
    public IScreen HostScreen { get; }

    public QuestionViewModel(IScreen hostScreen, Question question)
    {
        HostScreen = hostScreen;
        UrlPathSegment = "question_" + new Guid().ToString()[..5];

        _question = question;

        this.WhenAnyValue(x => x.ChosenAnswerIndex)
            .ObserveOn(RxApp.MainThreadScheduler)
            .Subscribe(val => _question.TryAnswer(val));
    }
}