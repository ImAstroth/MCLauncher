using System;
using System.Diagnostics;
using AstroLauncher.Utils.MinecraftControls;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using AstroLauncher.Launcher;

namespace AstroLauncher;

public partial class MainWindow : Window
{
    private readonly System.Threading.SemaphoreSlim _loadLock = new(1, 1);
    
    private readonly MinecraftActions _minecraftActions = new MinecraftActions();
    
    public MainWindow()
    {
        InitializeComponent();
        ExtendClientAreaToDecorationsHint = true;
        
		// launcher version
        
        
        // load on start
        // var savedAccount = Managers.AccountManager.Load();
        // if (savedAccount != null)
        // {
        //     UsernameBox.Text = savedAccount.Username;
        // }
    }
    
    private void OnMinimizeButtonClicked(object sender, RoutedEventArgs e)
    {
        WindowState = WindowState.Minimized;
    }

    private void OnCloseButtonClicked(object sender, RoutedEventArgs e)
    {
        Close();
    }

    private void OnFolderButtonClicked(object sender, RoutedEventArgs e)
    {
        Managers.FolderBtnManager.OpenMinecraftFolder();
    }
    
    public void OnSettingsButtonClicked(object sender, RoutedEventArgs e)
    {
        var settingsWin = new SettingsWindow();
        // 'this' makes the main window the owner, keeping things centered and modal
        settingsWin.ShowDialog(this);
    }
    
    // public async void OnLaunchButtonClicked(object sender, RoutedEventArgs e)
    // {
    //     await _minecraftActions.LaunchMinecraftAsync(VersionsMenu, UsernameBox);
    // }
    //
    // protected override async void OnOpened(EventArgs e)
    // {
    //     base.OnOpened(e);
    //     await _minecraftActions.LoadVersionsAsync(VersionsMenu);
    // }
    //
    // public void OnLoginClicked(object sender, RoutedEventArgs e)
    // {
    //     var input = UsernameBox.Text;
    //
    //     if (string.IsNullOrWhiteSpace(input))
    //     {
    //         return;
    //     }
    //
    //     var account = new LauncherAccount 
    //     { 
    //         Username = input,
    //         IsMicrosoft = false
    //     };
    //
    //     Managers.AccountManager.Save(account);
    //     
    //     Debug.WriteLine($"Saved: {account.DisplayName}");
    // }

    private void SetupDrag(object? sender, PointerPressedEventArgs e)
    {
        BeginMoveDrag(e);
    }
}