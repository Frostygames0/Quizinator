using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;

namespace Quizinator.Models.Quizzes;

public class Quiz
{
    [JsonPropertyName("name")]
    public required string Name { get; init; }
    [JsonPropertyName("description")]
    public required string Description { get; init; }
    [JsonPropertyName("author"), JsonRequired]
    public required string Author { get; init; }
    
    [JsonPropertyName("questions")]
    public required IList<Question> Questions { get; init; }
    
    [JsonConstructor, SetsRequiredMembers]
    public Quiz(string name, string description, string author, IList<Question> questions)
    {
        Name = name;
        Description = description;
        Author = author;
        
        Questions = questions?.AsReadOnly();
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
}