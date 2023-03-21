using System.Collections.Generic;
using ReactiveUI;

namespace Quizinator.ViewModels.Quizzes;

public interface IQuestionViewModel : IRoutableViewModel
{
    int ChosenAnswerIndex { get; set; }
    
    string Question { get; }
    IList<string> Answers { get; }
}