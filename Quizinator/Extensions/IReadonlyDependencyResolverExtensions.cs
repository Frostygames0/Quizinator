using System;
using Splat;

namespace Quizinator.Extensions;

public static class IReadonlyDependencyResolverExtensions
{
    // Extension for IReadonlyDependencyResolver so it stops warning me about service possibly being null
    public static T GetImportantService<T>(this IReadonlyDependencyResolver resolver, string? contract = null)
    {
        var service = resolver.GetService<T>(contract);
        if (service is null)
            throw new NullReferenceException($"Important service {typeof(T)} is not found!");

        return service;
    }
}
