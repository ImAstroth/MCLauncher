using Avalonia.Data;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AstroLauncher.ViewModels;

public partial class InstancesViewModel : ObservableObject
{
    [ObservableProperty] 
    private string _pageTitle = "Manage Instances";

    [RelayCommand]
    private void LaunchMinecraft()
    {
       // add main logic later 
    }
    
    [RelayCommand]
    private void OpenMinecraftFolder()
    {
        Managers.FolderBtnManager.OpenMinecraftFolder();
    }
}