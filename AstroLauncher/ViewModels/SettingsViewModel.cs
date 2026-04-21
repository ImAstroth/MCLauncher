using Avalonia.Controls;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AstroLauncher.ViewModels;

public partial class SettingsViewModel : ObservableObject
{
    [ObservableProperty] private string _pageTitle = "Settings";

    // RAM values
    [ObservableProperty] private double _maxRamValue = 16384;
    [ObservableProperty] private double _currentRamValue = 0;
}