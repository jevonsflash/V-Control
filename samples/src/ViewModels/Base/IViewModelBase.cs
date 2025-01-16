using VControl.Samples.Services.Navigation;

namespace VControl.Samples.ViewModels;

public interface IViewModelBase : IQueryAttributable
{
    INavigationService NavigationService { get; }


    IAsyncRelayCommand InitializeAsyncCommand { get; }


    bool IsBusy { get; }
    string PageTitle { get; }

    bool IsInitialized { get; }

    /// <summary>
    /// 页面初始化
    /// </summary>
    /// <returns></returns>
    Task InitializeAsync();
}

