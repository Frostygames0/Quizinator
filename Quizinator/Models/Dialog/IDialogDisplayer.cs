using System.Threading.Tasks;
using Quizinator.ViewModels.Dialogs;

namespace Quizinator.Models.Dialog;

public interface IDialogDisplayer
{
    Task<TResult> ShowDialogAsync<T, TResult>(T viewModel) where T : DialogViewModelBase<TResult>;
}