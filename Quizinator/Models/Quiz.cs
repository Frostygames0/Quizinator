using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;

namespace Quizinator.Models;

public class Quiz
{
    [JsonInclude, JsonPropertyName("Name")]
    private readonly string _name;
    [JsonInclude, JsonPropertyName("Description")]
    private readonly string _description;
    [JsonInclude, JsonPropertyName("Author")]
    private readonly string _author;
    
    public IList<Question> Questions { get; }
    
    [JsonIgnore]
    public string DisplayName => _name + $"(by {_author})";
    [JsonIgnore]
    public string Description => _description;
    

    public Quiz(string name, string description, string author, IList<Question> questions)
    {
        _name = name;
        _description = description;
        _author = author;

        Questions = questions.AsReadOnly();
    }

    public int CalculateResults()
    {
        return Questions.Count(question => question.CheckAnswer());
    }

    public override string ToString()
    {
        var builder = new StringBuilder();
        builder.Append($"Quiz - {DisplayName} \n");
        foreach (var question in Questions)
        {
            builder.Append(question + "\n");
        }

        return builder.ToString();
    }
}