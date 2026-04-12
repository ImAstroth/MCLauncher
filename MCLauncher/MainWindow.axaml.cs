using System;
using System.Diagnostics;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;

using MCLauncher.Utils.MinecraftControls;

namespace MCLauncher;

public partial class MainWindow : Window
{
    private readonly System.Threading.SemaphoreSlim _loadLock = new(1, 1);
    
    public MinecraftActions MinecraftActions = new MinecraftActions();
    
    public MainWindow()
    {
        InitializeComponent();
        ExtendClientAreaToDecorationsHint = true;
        
        // load on start
        var savedAccount = Managers.AccountManager.Load();
        if (savedAccount != null)
        {
            UsernameBox.Text = savedAccount.Username;
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

    private void OnFolderButtonClicked(object sender, RoutedEventArgs e)
    {
        Managers.FolderBtnManager.OpenMinecraftFolder();
    }
    
    public async void OnLaunchButtonClicked(object sender, RoutedEventArgs e)
    {
        await MinecraftActions.LaunchMinecraftAsync(VersionsMenu, UsernameBox);
    }
    
    protected override async void OnOpened(EventArgs e)
    {
        base.OnOpened(e);
        await MinecraftActions.LoadVersionsAsync(VersionsMenu);
    }

    public void OnLoginClicked(object sender, RoutedEventArgs e)
    {
        var input = UsernameBox.Text;

        if (string.IsNullOrWhiteSpace(input))
        {
            // dont save garbage.
            return;
        }

        var account = new LauncherAccount 
        { 
            Username = input,
            IsMicrosoft = false
        };

        Managers.AccountManager.Save(account);
        
        Debug.WriteLine($"Saved: {account.DisplayName}");
    }
    

    private void SetupDrag(object? sender, PointerPressedEventArgs e)
    {
        BeginMoveDrag(e);
    }
}