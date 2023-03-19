using System.Collections.Generic;
using System.Threading.Tasks;

namespace Quizinator.Models;

public interface IQuizSearcher
{
    IEnumerable<Quiz> FoundQuizzes { get; }

    Task<bool> TryUpdateSearch(string? searchPath = null);
}