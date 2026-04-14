using System.IO;
using System.Text.Json;
using AstroLauncher.Launcher;

namespace AstroLauncher.JSON;

public static class Json
{
    public static void SaveConfig(LauncherConfig config)
    {
        string json = JsonSerializer.Serialize(config, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText("config.json", json);
    }
    
    public static LauncherConfig LoadConfig()
    {
        if (!File.Exists("config.json")) return new LauncherConfig(); // return defaults
    
        string json = File.ReadAllText("config.json");
        return JsonSerializer.Deserialize<LauncherConfig>(json) ?? new LauncherConfig();
    }
}