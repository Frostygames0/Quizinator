using System;
using System.IO;

namespace Quizinator;

public static class Directories
{
    public static readonly string App = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);

    public static readonly string Quizzes = Path.Combine(App, "quizzes");

    public static void CreateAppDirectories()
    {
        Directory.CreateDirectory(Quizzes); 
    }
}