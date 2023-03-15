namespace Quizinator.Models;

public interface ISettings
{
    public string QuizzesLocation { get; set; }

    void Save();

    void Load();
}