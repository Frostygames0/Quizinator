using System.Collections.Generic;
using System.Threading.Tasks;
using Avalonia.Controls;
using Quizinator.Views.Providers;

namespace Quizinator.Models.Dialog;

public class SystemDialogService : ISystemDialogService
{
    private readonly IMainWindowProvider _provider;
    
    public SystemDialogService(IMainWindowProvider provider)
    {
        _provider = provider;
    }

    public async Task<string[]?> OpenFile(bool allowMultiple = false, FileDialogFilter? filter = null, string? defaultFileName = null)
    {
        var dialog = new OpenFileDialog
        {
            AllowMultiple = allowMultiple,
            InitialFileName = defaultFileName
        };
        
        if (filter is not null)
            dialog.Filters = new List<FileDialogFilter> {filter};

        var window = _provider.ProvideMainWindow();
        return await dialog.ShowAsync(window);
    }

    public async Task<string?> SaveFile(string? defaultFileName = null)
    {
        var dialog = new SaveFileDialog
        {
            InitialFileName = defaultFileName
        };
        
        var window = _provider.ProvideMainWindow();
        return await dialog.ShowAsync(window);
    }

    public async Task<string?> OpenFolder(string? defaultDirectory = null)
    {
        var dialog = new OpenFolderDialog
        {
            Directory = defaultDirectory
        };
        
        var window = _provider.ProvideMainWindow();
        return await dialog.ShowAsync(window);
    }
}