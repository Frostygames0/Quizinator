using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace Quizinator.Models;

public class Question
{
    [JsonInclude]
    [JsonPropertyName("CorrectAnswerIndex")]
    private readonly int _correctAnswerIndex;

    private int _givenAnswer;
    private bool _wasAnswered;
    
    [JsonPropertyName("Question")]
    public string LiteralQuestion { get; }
    public IList<string> Answers { get; }
    
    public Question(string literalQuestion, IList<string> answers, int correctAnswerIndex)
    {
        LiteralQuestion = literalQuestion;
        Answers = answers.AsReadOnly();

        if (!ValidateIndex(correctAnswerIndex))
            throw new ArgumentOutOfRangeException(
                $"Index should be in range of [0,{Answers.Count}]! Was: {correctAnswerIndex}");
        
        _correctAnswerIndex = correctAnswerIndex;
    }
    
    public bool TryAnswer(int index)
    {
        if (!ValidateIndex(index) || _wasAnswered) 
            return false;
        
        _givenAnswer = index;
        _wasAnswered = true;
        
        return true;
    }

    public bool CheckAnswer()
    {
        return _givenAnswer == _correctAnswerIndex;
    }

    private bool ValidateIndex(int index)
    {
        return index <= Answers.Count && index >= 0;
    }

    public override string ToString()
    {
        return $"Question: {LiteralQuestion} \n Answers: " + string.Join(',', Answers);
    }
}