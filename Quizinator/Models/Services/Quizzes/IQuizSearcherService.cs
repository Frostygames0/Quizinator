using System.Collections.Generic;
using System.Threading.Tasks;
using Quizinator.Models.Quizzes;

namespace Quizinator.Models.Services.Quizzes;

public interface IQuizSearcherService
{
    IEnumerable<Quiz> FoundQuizzes { get; }

    Task<bool> TrySearch(string? searchPath = null);
}