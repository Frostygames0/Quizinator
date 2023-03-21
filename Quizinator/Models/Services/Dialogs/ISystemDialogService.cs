using System.Threading.Tasks;
using Avalonia.Controls;

namespace Quizinator.Models.Services.Dialogs;

public interface ISystemDialogService
{
    Task<string[]?> OpenFile(bool allowMultiple = false, FileDialogFilter? filter = null, string? defaultFileName = null);
    
    Task<string?> SaveFile(string? defaultFileName = null);

    Task<string?> OpenFolder(string? defaultDirectory = null);
}