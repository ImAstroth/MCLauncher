using Avalonia.Controls;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AstroLauncher.ViewModels;

public partial class SettingsViewModel : ObservableObject
{
    [ObservableProperty] 
    private string _pageTitle = "Settings";
}