using System.Collections.Generic;
using System.Threading.Tasks;

namespace Quizinator.Models;

public interface IQuizSearcherService
{
    IEnumerable<Quiz> FoundQuizzes { get; }

    Task<bool> TrySearch(string? searchPath = null);
}