using System.Threading.Tasks;
using Quizinator.ViewModels.Dialogs;

namespace Quizinator.Models.Services.Dialogs;

public interface IDialogService
{
    Task<TResult> ShowDialogAsync<TResult>(DialogViewModelBase<TResult> viewModel);
    
    Task ShowDialogAsync(DialogViewModelBase viewModel);
}