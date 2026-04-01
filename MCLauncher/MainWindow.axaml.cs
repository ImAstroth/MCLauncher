using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using CmlLib.Core;
using CmlLib.Core.Auth;
using CmlLib.Core.ProcessBuilder;

using MCLauncher.Utils;

namespace MCLauncher;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        ExtendClientAreaToDecorationsHint = true;
    }
    
    private void MinimizeButton_Click(object sender, RoutedEventArgs e)
    {
        WindowState = WindowState.Minimized;
    }

    private void CloseButton_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }
    
    public async void OnLaunchButtonClicked(object sender, RoutedEventArgs e)
    {
        await LaunchMinecraftAsync();
    }
    
    protected override async void OnOpened(EventArgs e)
    {
        base.OnOpened(e);
        await LoadVersionsAsync();
    }

    private async Task LoadVersionsAsync()
    {
        var path = MinecraftPath.GetOSDefaultPath();
        var launcher = new MinecraftLauncher(path);
        
        // fetch versions
        try
        {
            var allVersions = await launcher.GetAllVersionsAsync();
            
            // filter versions only for releases (v is version btw)
            var releasesOnly = allVersions
                .Where(v => v.Type == "release")
                .Select(v => v.Name)
                .ToList();
            
            // update drop down
            VersionsMenu.ItemsSource = releasesOnly;
        
            // set a default so it is not empty
            VersionsMenu.SelectedIndex = 0;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private async Task LaunchMinecraftAsync()
    {
        try 
        {
            string? selectedVersion = VersionsMenu.SelectedItem as string;
            string username = UsernameBox.Text ?? "Player";

            if (string.IsNullOrEmpty(selectedVersion))
            {
                Debug.WriteLine("Error: You must select a version first!");
                return;
            }
            
            var path = MinecraftPath.GetOSDefaultPath();
            var launcher = new MinecraftLauncher(path);

            var launchOption = new MLaunchOption
            {
                MaximumRamMb = 2048,
                Session = MSession.CreateOfflineSession(username),
            };

            Debug.WriteLine($"[Astro] Launching {selectedVersion} for {username}...");

            var process = await launcher.CreateProcessAsync(selectedVersion, launchOption);
        
            process.Start();
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"[Launch Error]: {ex.Message}");
        }
    }

    private void SetupDrag(object? sender, PointerPressedEventArgs e)
    {
        BeginMoveDrag(e);
    }
}