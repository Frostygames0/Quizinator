using ReactiveUI;

namespace Quizinator.ViewModels.Factory;

public interface IMainMenuViewModelFactory
{
    IMainMenuViewModel Create(IScreen hostScreen);
}