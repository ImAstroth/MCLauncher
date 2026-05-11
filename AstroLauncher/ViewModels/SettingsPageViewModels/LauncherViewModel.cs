using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AstroLauncher.ViewModels.SettingsPageViewModels;

public partial class LauncherViewModel : ViewModelBase
{
    public LauncherViewModel()
    {
        DisplayName = "Launcher";
        IconData = StreamGeometry.Parse("m14.305 7.53.923-.382 m15.228 4.852-.923-.383 m16.852 3.228-.383-.924 m16.852 8.772-.383.923 m19.148 3.228.383-.924 m19.53 9.696-.382-.924 m20.772 4.852.924-.383 m20.772 7.148.924.383 M22 13v2a2 2 0 0 1-2 2H4a2 2 0 0 1-2-2V5a2 2 0 0 1 2-2h7 M8 21h8");
    }
}