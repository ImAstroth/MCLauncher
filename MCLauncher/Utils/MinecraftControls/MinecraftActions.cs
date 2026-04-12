using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Avalonia.Controls;
using CmlLib.Core;
using CmlLib.Core.Auth;
using CmlLib.Core.Installers;
using CmlLib.Core.ProcessBuilder;

using MCLauncher.Utils;

namespace MCLauncher.Utils.MinecraftControls;

public class MinecraftActions
{
    private readonly System.Threading.SemaphoreSlim _loadLock = new(1, 1);
    
    public async Task LoadVersionsAsync(ComboBox versionsMenu)
    {
        await _loadLock.WaitAsync();

        try
        {
            var path = Minecraft.GetMinecraftPath();
            var launcher = new MinecraftLauncher(path);

            var allVersions = await launcher.GetAllVersionsAsync();
        
            var releasesOnly = allVersions
                .Where(v => v.Type == "release")
                .Select(v => v.Name)
                .ToList();
        
            versionsMenu.ItemsSource = releasesOnly;
            versionsMenu.SelectedIndex = 0;
        }
        catch (Exception e)
        {
            Debug.WriteLine($"[Load Error]: {e.Message}");
        }
        finally
        {
            _loadLock.Release();
        }
    }

    public async Task LaunchMinecraftAsync(ComboBox versionsMenu, TextBox usernameBox)
    {
        try 
        {
            string? selectedVersion = versionsMenu.SelectedItem as string;
            string username = usernameBox.Text ?? "Player";

            if (string.IsNullOrEmpty(selectedVersion)) return;

            var path = Minecraft.GetMinecraftPath();
            var launcher = new MinecraftLauncher(path);
            

            var launchOption = new MLaunchOption
            {
                MaximumRamMb = 2048,
                Session = MSession.CreateOfflineSession(username),
            };

            var process = await launcher.CreateProcessAsync(selectedVersion, launchOption);
        
            process.Start();
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"[Launch Error]: {ex.Message}");
        }
    }
}