using System.Threading.Tasks;
using Quizinator.ViewModels.Dialogs;

namespace Quizinator.Models.Services.Dialogs;

public interface IDialogService
{
    Task<TResult> ShowDialogAsync<T, TResult>(T viewModel) where T : DialogViewModelBase<TResult>;
    
    Task ShowDialogAsync<T>(T viewModel) where T : DialogViewModelBase;
}