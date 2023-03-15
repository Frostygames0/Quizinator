using System.Text.Json;
using Quizinator.Models;

namespace QuizinatorTest;

[TestFixture]
public class SerializationQuizTesting
{
    private string _json;
    private Quiz? _deserialized;
    
    [SetUp]
    public void Setup()
    {
        _json = @"{
        ""name"": ""Coolest Quiz Ever"",
        ""description"": ""THIS IS THE COOLEST QUIZ YOU'VE NEVER SEEN BEFORE"",
        ""author"": ""FrostyGOD232223"",
	
        ""questions"":
        [
        {
            ""question"": ""Why?"",
            ""answers"": [""Aboba"", ""Pepe"", ""EEEEEEEE""],
            ""correctAnswerIndex"": 1
        }
        ]
        }";
        
        _deserialized = JsonSerializer.Deserialize<Quiz>(_json);
    }
    [Test]
    public void DeserializationTest()
    {
        Assert.NotNull(_deserialized);
        
        Assert.Multiple(() =>
        {
            Assert.True(_deserialized.Name == "Coolest Quiz Ever");
            Assert.True(_deserialized.Description == "THIS IS THE COOLEST QUIZ YOU'VE NEVER SEEN BEFORE");
            Assert.True(_deserialized.Author == "FrostyGOD232223");
            
            Assert.True(_deserialized.Questions.Count == 1);
            
            var question = _deserialized.Questions[0];
            Assert.True(question.LiteralQuestion == "Why?");
            
            Assert.True(question.Answers[0] == "Aboba");
            Assert.True(question.Answers[1] == "Pepe");
            Assert.True(question.Answers[2] == "EEEEEEEE");
            
            Assert.True(question.CorrectAnswerIndex == 1);
            
            Console.WriteLine(_deserialized);
        });
    }
    
    [Test]
    public void SerializationTest()
    {
        string serialized = JsonSerializer.Serialize(_deserialized, new JsonSerializerOptions {WriteIndented = true});
        Console.WriteLine(serialized);
        Assert.Pass();
    }
}