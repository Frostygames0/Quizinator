using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Quizinator.Models.Quizzes;

public class Question
{
    private int _givenAnswer;
    private bool _wasAnsweredBefore;

    [JsonPropertyName("question")]
    public required string LiteralQuestion { get; init; }
    [JsonPropertyName("answers")]
    public required IList<string> Answers { get; init; }
    [JsonPropertyName("correctAnswerIndex")]
    public required int CorrectAnswerIndex { get; init; }
    
    [JsonConstructor, SetsRequiredMembers]
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