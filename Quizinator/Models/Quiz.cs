using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Quizinator.Models;

public class Quiz
{
    [JsonPropertyName("name")]
    public string Name { get; }
    [JsonPropertyName("description")]
    public string Description { get; }
    [JsonPropertyName("author")]
    public string Author { get; }
    
    [JsonPropertyName("questions")]
    public IList<Question> Questions { get; }
    
    [JsonConstructor]
    public Quiz(string name, string description, string author, IList<Question> questions)
    {
        Name = name;
        Description = description;
        Author = author;

        Questions = questions.AsReadOnly();
    }

    public int CalculateResults()
    {
        return Questions.Count(question => question.CheckAnswer());
    }

    public override string ToString()
    {
        var builder = new StringBuilder();
        builder.Append($"Quiz - {Name},\nDescription - {Description},\nAuthor - {Author}");
        foreach (var question in Questions)
        {
            builder.Append(question + "\n");
        }

        return builder.ToString();
    }

    public static async Task<IEnumerable<Quiz>> FindQuizzesAsync(string searchDirectory)
    {
        var quizzes = new List<Quiz>();
        
        if (!Directory.Exists(searchDirectory))
            return quizzes;
        
        var foundFiles = Directory.EnumerateFiles(searchDirectory, "*.json");
        
        foreach(var file in foundFiles)
        {
            await using var stream = File.OpenRead(file);
            Quiz? result = await JsonSerializer.DeserializeAsync<Quiz>(stream);
            
            if (result is null)
                continue;

            quizzes.Add(result);
        }

        return quizzes;
    }
}