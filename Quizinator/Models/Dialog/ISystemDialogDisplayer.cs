using System.Threading.Tasks;
using Avalonia.Controls;

namespace Quizinator.Models.Dialog;

public interface ISystemDialogDisplayer
{
    Task<string[]?> OpenFile(bool allowMultiple = false, FileDialogFilter? filter = null, string? defaultFileName = null);
    
    Task<string?> SaveFile(string? defaultFileName = null);

    Task<string?> OpenFolder(string? defaultDirectory = null);
}