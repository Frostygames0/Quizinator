using Quizinator.Models.Quizzes;

namespace Quizinator.ViewModels.Dialogs.Quizzes.Factory;

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
    
    public IQuizDialogViewModel Create(Quiz quiz)
    {
        return new QuizDialogViewModel(quiz, _quizIntroFactory, _quizResultsFactory, _questionFactory);
    }
}