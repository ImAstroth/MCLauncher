using System;
using System.IO;
using System.Diagnostics;

namespace MCLauncher.Managers;

public static class FolderBtnManager
{
    
    public static void OpenMinecraftFolder()
    {
        string minecraftPath = Utils.Minecraft.GetMinecraftPath();

        try
        {
            if (Directory.Exists(minecraftPath))
            {
                var startInfo = new ProcessStartInfo
                {
                    FileName = minecraftPath,
                    UseShellExecute = true
                };
                Process.Start(startInfo);
            }
            else
            {
                Utils.DebugUtil.Error("Folder not found.");
            }
        }
        catch (Exception e)
        {
            Utils.DebugUtil.Error($"Failed to open folder: {e.Message}");
        }
    }
}