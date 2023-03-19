using System.Collections.Generic;
using System.Threading.Tasks;

namespace Quizinator.Models;

public interface IQuizSearcher
{
    IEnumerable<Quiz> FoundQuizzes { get; }

    Task<bool> TrySearch(string? searchPath = null);
}