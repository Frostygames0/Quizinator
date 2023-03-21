using System.Diagnostics;
using System.Text.Json;
using Quizinator.Models;
using Quizinator.Models.Quizzes;

namespace QuizinatorTest;

[TestFixture]
public class QuizTesing
{
    private Quiz _quiz;

    [OneTimeSetUp]
    public void OneTimeSetup()
    {
        Trace.Listeners.Add(new ConsoleTraceListener());
    }
    
    [SetUp]
    public void Setup()
    {
        var questions = new List<Question>
        {
            new("How are you?", new List<string> {"fine", "bad", "im dumb"}, 0),
            new("Do you like eating cerea;?", new List<string> {"ofc", "no", "im yupidapipu"}, 2),
            new("Why are you bebra?", new List<string> {"cuz why not", "nobebe", "yesebe"}, 1),
            new("Do you hate flies?", new List<string> {"yes", "no"}, 0)
        };
        
        _quiz = new Quiz("Test Quiz", "Lorem ipsum dolor sit amet", "Testing", questions);

        Debug.WriteLine(_quiz);
    }

    [Test]
    public void OneIncorrectTest()
    {
        _quiz.Questions[0].TryAnswer(0);
        _quiz.Questions[1].TryAnswer(2);
        _quiz.Questions[2].TryAnswer(2);
        _quiz.Questions[3].TryAnswer(0);

        Assert.True(_quiz.CalculateResults() == 3);
    }
    
    [Test]
    public void AllIncorrectTest()
    {
        _quiz.Questions[0].TryAnswer(1);
        _quiz.Questions[1].TryAnswer(0);
        _quiz.Questions[2].TryAnswer(2);
        _quiz.Questions[3].TryAnswer(1);

        Assert.True(_quiz.CalculateResults() == 0);
    }
    
    [Test]
    public void CantAnswerTwiceTest()
    {
        var questionZero = _quiz.Questions[0];
        questionZero.TryAnswer(0);
        
        Assert.False(questionZero.TryAnswer(0));
    }
}