namespace AstroLauncher.Launcher;

public class LauncherAccount
{
    public string Username { get; set; }
    public bool IsMicrosoft { get; set; }
    public string? RefreshToken { get; set; } // ONLY IF MICROSOFT ACCOUNT
    
    // to show in list
    public string DisplayName => IsMicrosoft ? $"{Username} (Microsoft)" : $"{Username} (Offline)";
}