using Quizinator.Models.Quizzes;

namespace Quizinator.ViewModels.Dialogs.Quizzes.Factory;

public interface IQuizViewModelFactory
{
    IQuizDialogViewModel Create(Quiz quiz);
}