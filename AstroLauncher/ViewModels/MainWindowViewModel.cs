using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AstroLauncher.ViewModels;

public partial class MainWindowViewModel : ObservableObject
{
    [ObservableProperty]
    private string _versionText = "v1.0.0";
    
    [ObservableProperty]
    private ObservableObject? _currentPage;

    public MainWindowViewModel()
    {
        CurrentPage = new HomeViewModel();
    }

    [RelayCommand]
    private void NavigateToInstances()
    {
        CurrentPage =  new InstancesViewModel();
    }

    [RelayCommand]
    private void NavigateToHome()
    {
        CurrentPage = new HomeViewModel();
    }

    [RelayCommand]
    private void NavigateToDiscover()
    {
        CurrentPage = new DiscoverViewModel();
    }
    
    [RelayCommand]
    private void NavigateToSettings(Window owner)
    {
        CurrentPage = new SettingsViewModel();
    }
}