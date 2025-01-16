using Microsoft.Maui.Platform;
using VControl.Samples.Services.Navigation;

namespace VControl.Samples;

public partial class App : Application
{
    public App(INavigationService navigationService)
    {
        InitializeComponent();
        InitApp();
        MainPage = new AppShell(navigationService);
    }

    private void InitApp()
    {
        if (VersionTracking.IsFirstLaunchEver)
        {
            //首次打开
        }
    }


    protected override async void OnStart()
    {
        base.OnStart();
        
        //code snippet
        OnResume();
    }
}
