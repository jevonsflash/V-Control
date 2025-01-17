using System.Diagnostics;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using AndroidX.Activity.Result;
using static AndroidX.Activity.Result.Contract.ActivityResultContracts;

namespace VControl.Samples;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ScreenOrientation = ScreenOrientation.Portrait, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
    internal static ActivityResultLauncher UpdateFlowLauncher { get; private set; }
    protected override void OnCreate(Bundle savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
        Platform.Init(this, savedInstanceState);

        UpdateFlowLauncher = this.RegisterForActivityResult(new StartIntentSenderForResult(), new ActivityResultCallback());
    }

    public MainActivity()
    {
        AndroidEnvironment.UnhandledExceptionRaiser += UnhandledException;
        AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

    }

    private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
    {
        System.Diagnostics.Debug.WriteLine(e.ExceptionObject);

    }

    private void UnhandledException(object sender, RaiseThrowableEventArgs e)
    {
        System.Diagnostics.Debug.WriteLine(e.Exception);

    }

    //protected override void OnNewIntent(Intent intent)
    //{
    //    base.OnNewIntent(intent);
    //    HandleIntent(intent);
    //}

    //private static void HandleIntent(Intent intent)
    //{
    //    FirebaseCloudMessagingImplementation.OnNewIntent(intent);
    //}

    //private void CreateNotificationChannelIfNeeded()
    //{
    //    if (Build.VERSION.SdkInt >= BuildVersionCodes.O)
    //    {
    //        CreateNotificationChannel();
    //    }
    //}

    //private void CreateNotificationChannel()
    //{
    //    var channelId = $"{PackageName}.general";
    //    var notificationManager = (NotificationManager)GetSystemService(NotificationService);
    //    var channel = new NotificationChannel(channelId, "General", NotificationImportance.Default);
    //    notificationManager.CreateNotificationChannel(channel);
    //    FirebaseCloudMessagingImplementation.ChannelId = channelId;
    //    //FirebaseCloudMessagingImplementation.SmallIconRef = Resource.Drawable.ic_push_small;
    //}
}

public class ActivityResultCallback : Java.Lang.Object, IActivityResultCallback
{
    public void OnActivityResult(Java.Lang.Object result)
    {
        //立刻更新，不会返回RESULT_OK，暂时不处理
        //var r = (AndroidX.Activity.Result.ActivityResult)result;
        //if (r.ResultCode != RESULT_OK)
        //{

        //}
    }
}
