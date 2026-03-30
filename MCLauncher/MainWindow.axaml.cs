using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Avalonia.Controls;
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
    }
    
    public async void OnLaunchButtonClicked(object sender, RoutedEventArgs e)
    {
        await LaunchMinecraftAsync();
    }

    private async Task LaunchMinecraftAsync()
    {
        try 
        {
            var path = MinecraftPath.GetOSDefaultPath();
            var launcher = new MinecraftLauncher(path);

            var launchOption = new MLaunchOption
            {
                MaximumRamMb = 2048,
                Session = MSession.CreateOfflineSession("User") 
            };

            Console.WriteLine("[CmlLib] Verifying files and launching...");

            var process = await launcher.CreateProcessAsync("1.20.1", launchOption);
            process.Start();
        
            Console.WriteLine("Starting game...");
        }
        catch (Exception ex)
        {
            DebugUtil.Error($"[CmlLib Error]: {ex.Message}");
        }
    }
}