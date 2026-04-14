using System;
using System.IO;
using System.Text.Json;
using AstroLauncher.Launcher;

namespace AstroLauncher.Managers;

public static class AccountManager
{
    private static readonly string ConfigPath = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), 
        "AstroLauncher", 
        "account.json"
    );

    public static void Save(LauncherAccount account)
    {
        try
        {
            string directory = Path.GetDirectoryName(ConfigPath)!;
            if (!Directory.Exists(directory)) Directory.CreateDirectory(directory);
            
            var json = JsonSerializer.Serialize(account, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            File.WriteAllText(ConfigPath, json);
        }
        catch (Exception ex)
        {
            Utils.DebugUtil.Error(ex.Message);
        }
    }

    public static LauncherAccount? Load()
    {
        if (!File.Exists(ConfigPath)) return null;
        
        if (!File.Exists(ConfigPath)) return null;

        try
        {
            var json = File.ReadAllText(ConfigPath);
            return JsonSerializer.Deserialize<LauncherAccount>(json);
        }
        catch (Exception ex)
        {
            Utils.DebugUtil.Error(ex.Message);
            return null;
        }
    }
}