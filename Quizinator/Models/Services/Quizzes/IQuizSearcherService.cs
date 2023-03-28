using System;
using System.Threading.Tasks;
using DynamicData;
using Quizinator.Models.Quizzes;

namespace Quizinator.Models.Services.Quizzes;

public interface IQuizSearcherService
{
    Task RefreshSearchAsync(string? searchPath = null);

    IObservable<IChangeSet<Quiz>> Connect();
}