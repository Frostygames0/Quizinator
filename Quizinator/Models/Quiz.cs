using System.Collections.Generic;

namespace Quizinator.Models;

public class Quiz
{
    private readonly string _name;
    private readonly string _description;
    private readonly string _author;
    
    private readonly Queue<Question> _questions;

    public string DisplayName => _name + $"(by {_author})";
    public string Description => _description;
    public int QuestionCount => _questions.Count;

    public Quiz(string name, string description, string author, Queue<Question> questions)
    {
        _name = name;
        _description = description;
        _author = author;

        _questions = questions;
    }
}