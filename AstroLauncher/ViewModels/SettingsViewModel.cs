using System.Collections.ObjectModel;
using AstroLauncher.ViewModels.SettingsPageViewModels;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AstroLauncher.ViewModels;

public partial class SettingsViewModel : ViewModelBase
{
    [ObservableProperty]
    private ViewModelBase? _selectedCategory;

    public ObservableCollection<ViewModelBase> Categories { get; } = new()
    {
        new GeneralViewModel(),
        new LauncherViewModel(),
    };

    public SettingsViewModel()
    {
        DisplayName = "Settings";
        IconData = StreamGeometry.Parse("M9.671 4.136a2.34 2.34 0 0 1 4.659 0 2.34 2.34 0 0 0 3.319 1.915 2.34 2.34 0 0 1 2.33 4.033 2.34 2.34 0 0 0 0 3.831 2.34 2.34 0 0 1-2.33 4.033 2.34 2.34 0 0 0-3.319 1.915 2.34 2.34 0 0 1-4.659 0 2.34 2.34 0 0 0-3.32-1.915 2.34 2.34 0 0 1-2.33-4.033 2.34 2.34 0 0 0 0-3.831A2.34 2.34 0 0 1 6.35 6.051a2.34 2.34 0 0 0 3.319-1.915"); 
        SelectedCategory = Categories[0];
    }

    [RelayCommand]
    private void NavigateToGeneral()
    {
        SelectedCategory =  new GeneralViewModel();
    }

    [RelayCommand]
    private void NavigateToLauncher()
    {
        SelectedCategory = new LauncherViewModel();
    }
}