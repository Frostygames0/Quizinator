using System;
using System.Collections.Generic;

namespace Quizinator.Models;

public class Question
{
    private readonly string _question;
    private readonly IList<string> _answers;
    private readonly int _correctAnswerIndex;

    public Question(string question, IList<string> answers, int correctAnswerIndex)
    {
        _question = question;
        _answers = answers;

        if (_answers.Count > correctAnswerIndex || correctAnswerIndex < 0)
            throw new ArgumentOutOfRangeException(
                $"Index should be in range of [0,{_answers.Count}]! Was: {correctAnswerIndex}");
        
        _correctAnswerIndex = correctAnswerIndex;
    }
}