using System;
using System.Text.Json.Serialization;

namespace Quizinator.Models;

public class Settings : ISettings
{
    [JsonPropertyName("quizzes_location")]
    public string QuizzesLocation { get; set; }
    
    public void Save()
    {
        throw new NotImplementedException();
    }

    public void Load()
    {
        throw new NotImplementedException();
    }
}