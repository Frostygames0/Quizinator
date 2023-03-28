using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Quizinator.Models.Quizzes;

public class Question
{
    private int _givenAnswer;
    private bool _wasAnsweredBefore;

    [JsonPropertyName("question"), JsonRequired]
    public string LiteralQuestion { get; init; }
    [JsonPropertyName("answers"), JsonRequired]
    public IList<string> Answers { get; init; }
    [JsonPropertyName("correctAnswerIndex"), JsonRequired]
    public int CorrectAnswerIndex { get; init; }
    
    [JsonConstructor]
    public Question(string literalQuestion, IList<string> answers, int correctAnswerIndex)
    {
        LiteralQuestion = literalQuestion;
        Answers = answers.AsReadOnly();

        if (!ValidateIndex(correctAnswerIndex))
            throw new ArgumentOutOfRangeException(
                $"Index should be in range of [0,{Answers.Count}]! Was: {correctAnswerIndex}");

        CorrectAnswerIndex = correctAnswerIndex;
    }
    
    public bool TryAnswer(int index)
    {
        if (!ValidateIndex(index)) 
            return false;
        
        _givenAnswer = index;
        _wasAnsweredBefore = true;

        return true;
    }

    public bool CheckAnswer()
    {
        return _givenAnswer == CorrectAnswerIndex && _wasAnsweredBefore;
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