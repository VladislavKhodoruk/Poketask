using MonkeyCache.FileStore;

namespace Poketask;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        Barrel.ApplicationId = AppInfo.PackageName;

        MainPage = new AppShell();
    }
}
