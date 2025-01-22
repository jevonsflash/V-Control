using System.Diagnostics;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using VControl.Samples.Services.Navigation;

namespace VControl.Samples.ViewModels;

public abstract partial class ViewModelBase : ObservableObject, IViewModelBase
{
    private long _isBusy;
    [ObservableProperty]
    private string _backPath;
    public bool IsBusy => Interlocked.Read(ref _isBusy) > 0;

    [ObservableProperty]
    private bool _isInitialized;

    [ObservableProperty]
    private string _pageTitle;

    public INavigationService NavigationService { get; }

    /// <summary>
    /// 页面初始化时执行
    /// </summary>
	public IAsyncRelayCommand InitializeAsyncCommand { get; }

    protected CancellationTokenSource CancellationTokenSource { get; private set; }

    public ViewModelBase(INavigationService navigationService)
    {
        NavigationService = navigationService;
        this.CancellationTokenSource = new CancellationTokenSource();
    }

    /// <summary>
    /// 可根据传值条件选择性执行，执行顺序早于InitializeAsync
    /// </summary>
    /// <param name="query"></param>
    public virtual void ApplyQueryAttributes(IDictionary<string, object> query)
    {

    }

    /// <summary>
    /// 页面初始化，已调用了IsBusyFor。
    /// </summary>
    /// <returns></returns>
    public virtual Task InitializeAsync()
    {
        return Task.CompletedTask;
    }

    /// <summary>
    /// 离开页面时调用
    /// </summary>
    public virtual void OnNavigatedFrom()
    {
        CancelActiveRequests();
    }

    /// <summary>
    /// 取消所有请求，释放资源，防止内存泄漏，页面离开时调用，或者页面销毁时调用，或者页面切换时调用
    /// </summary>
    public void CancelActiveRequests()
    {
        if (this.CancellationTokenSource != null && !this.CancellationTokenSource.IsCancellationRequested)
        {
            this.CancellationTokenSource.Cancel();
            this.CancellationTokenSource.Dispose();
        }

        this.CancellationTokenSource = new CancellationTokenSource();
    }

    public async Task IsBusyFor(Func<Task> unitOfWork)
    {
        Interlocked.Increment(ref _isBusy);
        OnPropertyChanged(nameof(IsBusy));

        try
        {
            await unitOfWork();
        }
        finally
        {
            Interlocked.Decrement(ref _isBusy);
            OnPropertyChanged(nameof(IsBusy));
        }
    }


    /// <summary>
    /// 显示OK信息
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    public async Task AlertOkayAsync(string message)
    {
        var toast = Toast.Make(message, ToastDuration.Long);
        await toast.Show();
    }

    /// <summary>
    /// 显示警告
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    public async Task AlertWarningAsync(string message)
    {
        var options = new SnackbarOptions
        {
            BackgroundColor = Colors.Orange,
            TextColor = Colors.White,
            ActionButtonTextColor = Colors.White,
            CornerRadius = new CornerRadius(15),
        };

        var customSnackbar = Snackbar.Make(
            message,
            duration: TimeSpan.FromSeconds(30),
            visualOptions: options);

        await customSnackbar.Show();
    }

    /// <summary>
    /// 显示错误
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    public async Task AlertErrorAsync(string message)
    {
        var options = new SnackbarOptions
        {
            BackgroundColor = Colors.OrangeRed,
            TextColor = Colors.White,
            ActionButtonTextColor = Colors.White,
            CornerRadius = new CornerRadius(15),
            Font = Microsoft.Maui.Font.SystemFontOfSize(16),
        };

        var customSnackbar = Snackbar.Make(
            message,
            duration: TimeSpan.FromSeconds(30),
            visualOptions: options);

        await customSnackbar.Show();
    }

    public void DebugInfo(string message)
    {
        Debug.WriteLine(message);
    }

    [RelayCommand]
    public virtual async Task MessageAsync(string obj)
    {
        await this.AlertOkayAsync(obj);

    }

    [RelayCommand]
    public virtual async Task GoPageAsync(string page)
    {
        await IsBusyFor(
                async () =>
                {
                    await NavigationService.NavigateToAsync(page);
                });
    }


    [RelayCommand]
    public virtual async Task BackAsync()
    {
        await NavigationService.NavigateToAsync("..");
    }
}
