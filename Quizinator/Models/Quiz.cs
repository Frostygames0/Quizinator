using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;

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
}