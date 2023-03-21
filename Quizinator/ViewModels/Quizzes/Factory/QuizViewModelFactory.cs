using Quizinator.Models.Quizzes;
using ReactiveUI;

namespace Quizinator.ViewModels.Quizzes.Factory;

public class QuizViewModelFactory : IQuizViewModelFactory
{
    private readonly IQuizIntroViewModelFactory _quizIntroFactory;
    private readonly IQuizResultsViewModelFactory _quizResultsFactory;
    private readonly IQuestionViewModelFactory _questionFactory;
    
    public QuizViewModelFactory(IQuizIntroViewModelFactory quizIntroFactory,
        IQuizResultsViewModelFactory quizResultsFactory, IQuestionViewModelFactory questionFactory)
    {
        _quizIntroFactory = quizIntroFactory;
        _quizResultsFactory = quizResultsFactory;
        _questionFactory = questionFactory;
    }
    
    public IQuizViewModel Create(IScreen hostScreen, Quiz quiz, IRoutableViewModel viewModelToReturn)
    {
        return new QuizViewModel(hostScreen, quiz, viewModelToReturn, _quizIntroFactory, _quizResultsFactory, _questionFactory);
    }
}