using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;

namespace Quizinator.Models.Quizzes;

public class Quiz
{
    [JsonPropertyName("name"), JsonRequired]
    public string Name { get; init; }
    [JsonPropertyName("description"), JsonRequired]
    public string Description { get; init; }
    [JsonPropertyName("author"), JsonRequired]
    public string Author { get; init; }
    
    [JsonPropertyName("questions"), JsonRequired]
    public IList<Question> Questions { get; init; }
    
    [JsonConstructor]
    public Quiz(string name, string description, string author, IList<Question> questions)
    {
        Name = name;
        Description = description;
        Author = author;

        if (questions is null)
            throw new ArgumentNullException(nameof(questions),"Supposedly, JSON deserializer decided to wrongly serialize questions!");
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