using System.Collections.ObjectModel;
using AstroLauncher.ViewModels.SettingsPageViewModels;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AstroLauncher.ViewModels;

public partial class MainWindowViewModel : ObservableObject
{
    [ObservableProperty]
    private string _versionText = "v1.0.0";

    [ObservableProperty]
    private ViewModelBase? _activePage;

    [ObservableProperty] private ViewModelBase? _selectedBottomItem;
    [ObservableProperty] private ViewModelBase? _selectedTopItem;

    public ObservableCollection<ViewModelBase> TopCategories { get; } = new()
    {
        new HomeViewModel(),
        new InstancesViewModel(),
        new DiscoverViewModel(),
    };
    
    public ObservableCollection<ViewModelBase> BottomCategories { get; } = new()
    {
        new SettingsViewModel(),
    };
    
    partial void OnSelectedTopItemChanged(ViewModelBase? value)
    {
        if (value != null)
        {
            ActivePage = value;
            SelectedBottomItem = null; // unselect the bottom box
        }
    }

    partial void OnSelectedBottomItemChanged(ViewModelBase? value)
    {
        if (value != null)
        {
            ActivePage = value;
            SelectedTopItem = null; // unselect the top box
        }
    }

    public MainWindowViewModel()
    {
        SelectedTopItem = TopCategories[0];
    }
    
    [RelayCommand]
    private void NavigateToHome()
    {
        SelectedTopItem = TopCategories[0];
    }

    [RelayCommand]
    private void NavigateToInstances()
    {
        SelectedTopItem = TopCategories[1];
    }

    [RelayCommand]
    private void NavigateToDiscover()
    {
        SelectedTopItem = TopCategories[2];
    }
    
    [RelayCommand]
    private void NavigateToSettings(Window owner)
    {
        SelectedBottomItem = BottomCategories[0];
    }
}