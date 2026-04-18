using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AstroLauncher;

public partial class MainWindowViewModel : ObservableObject
{
    [ObservableProperty]
    private string _versionText = "v1.0.0";
    
    
    [RelayCommand]
    private void OpenMinecraftFolder()
    {
        Managers.FolderBtnManager.OpenMinecraftFolder();
    }
    
    [RelayCommand]
    private void OpenSettings(Window owner)
    {
        var settingsWin = new SettingsWindow();
        settingsWin.ShowDialog(owner);
    }
}