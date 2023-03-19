using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace Quizinator.Models;

public class QuizSearcher : IQuizSearcher
{
    private readonly string _defaultSearchPath;
    
    public IEnumerable<Quiz> FoundQuizzes { private set; get; }

    public QuizSearcher(string defaultSearchPath)
    {
        FoundQuizzes = new List<Quiz>();

        _defaultSearchPath = defaultSearchPath;
    }
    
    public async Task<bool> TrySearch(string? searchPath = null)
    {
        string concreteSearchPath = searchPath ?? _defaultSearchPath;
        
        var quizzes = new List<Quiz>();

        if (!Directory.Exists(concreteSearchPath))
            return false;
        
        var foundFiles = Directory.EnumerateFiles(concreteSearchPath, "*.json", SearchOption.AllDirectories);
        
        foreach(var file in foundFiles)
        {
            await using var stream = File.OpenRead(file);
            Quiz? result = await JsonSerializer.DeserializeAsync<Quiz>(stream);
            
            if (result is null)
                continue;

            quizzes.Add(result);
        }

        FoundQuizzes = quizzes;
        
        return true;
    }
}