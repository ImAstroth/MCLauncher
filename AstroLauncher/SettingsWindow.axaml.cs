using AstroLauncher.JSON;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;

namespace AstroLauncher;

public partial class SettingsWindow : Window
{
    public SettingsWindow()
    {
        InitializeComponent();
        LoadSettings();
    }

    private void LoadSettings()
    {
        var config = Json.LoadConfig();
        
        var ramSelector = this.FindControl<NumericUpDown>("RamSelector");
        if (ramSelector != null)
        {
            ramSelector.Maximum = config.MaxPhysicalRamMb;
            ramSelector.Value = config.SelectedRamMb;
        }
    }
    
    private void OnMinimizeButtonClicked(object sender, RoutedEventArgs e)
    {
        WindowState = WindowState.Minimized;
    }

    private void OnCloseButtonClicked(object sender, RoutedEventArgs e)
    {
        Close();
    }
    
    private void SetupDrag(object? sender, PointerPressedEventArgs e)
    {
        BeginMoveDrag(e);
    }
}