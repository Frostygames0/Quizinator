using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using DynamicData;
using Quizinator.Models.Quizzes;

namespace Quizinator.Models.Services.Quizzes;

public class QuizSearcherService : IQuizSearcherService
{
    private readonly string _defaultSearchPath;
    private readonly ISourceList<Quiz> _foundQuizzes;

    public QuizSearcherService(string defaultSearchPath)
    {
        _defaultSearchPath = defaultSearchPath;
        _foundQuizzes = new SourceList<Quiz>();
    }

    public IObservable<IChangeSet<Quiz>> Connect()
        => _foundQuizzes.Connect();

    public async Task RefreshSearchAsync(string? searchPath = null)
    {
        string concreteSearchPath = searchPath ?? _defaultSearchPath;
        
        var quizzes = new List<Quiz>();

        if (!Directory.Exists(concreteSearchPath))
            return;
        
        var foundFiles = Directory.EnumerateFiles(concreteSearchPath, "*.json", SearchOption.AllDirectories);
        
        foreach(var file in foundFiles)
        {
            var result = await DeserializeQuiz(file);
            
            if (result is null)
                continue;

            quizzes.Add(result);
        }
        
        _foundQuizzes.Edit(list =>
        {
            list.Clear();
            list.AddRange(quizzes);
        });
    }

    private static async Task<Quiz?> DeserializeQuiz(string file)
    {
        await using var stream = File.OpenRead(file);

        Quiz? quiz;
        try
        {
            quiz = await JsonSerializer.DeserializeAsync<Quiz>(stream);
        }
        catch
        {
            return null;
        }

        await stream.DisposeAsync();

        return quiz;
    }
}