using CommunityToolkit.Maui.Views;


namespace VControl.Samples.Services.Navigation;


public class MauiNavigationService : INavigationService
{
    private INavigation mainPageNavigation => mainShell.Navigation;
    private Shell mainShell => Shell.Current;

    public async Task InitializeAsync()
    {


        //jevons: 修改底栏，HOME
        await NavigateToAsync("//HomePage");
        //await NavigateToAsync("//MainPage");

    }

    public Task<Page> GetCurrentPageAsync()
    {
        return Task.FromResult(mainShell.CurrentPage);
    }

    public Task<Uri> GetCurrentUriAsync()
    {
        return Task.FromResult(mainShell.CurrentState.Location);
    }

    public Task NavigateToAsync(string route, IDictionary<string, object> routeParameters = null)
    {
        if (mainShell == null)
        {
            return Task.CompletedTask;
        }

        var currentViewModel = mainShell?.CurrentPage?.BindingContext;
        if (currentViewModel != null && currentViewModel is ViewModelBase viewModelBase)
        {
            viewModelBase.OnNavigatedFrom();
        }

        var shellNavigation = new ShellNavigationState(route);

        return routeParameters != null
            ? mainShell.GoToAsync(shellNavigation, routeParameters)
            : mainShell.GoToAsync(shellNavigation);
    }

    public Task NavigateToAsync<T>(IDictionary<string, object> routeParameters = null) where T : ContentPage
    {
        NavigateToAsync(typeof(T).Name, routeParameters);
        return Task.CompletedTask;
    }


    public async Task ShowPopupAsync(Popup popupPage)
    {
        if (popupPage == null)
        {
            return;
        }
        await mainShell.CurrentPage.ShowPopupAsync(popupPage);
    }
    public async Task HidePopupAsync(Popup popupPage)
    {
        if (popupPage == null)
        {
            return;
        }
        await popupPage.CloseAsync();
    }

    
    public async Task PushAsync(Page page, bool animated = true)
    {
        if (mainPageNavigation.NavigationStack.LastOrDefault() == page)
        {
            return;
        }
        await mainPageNavigation.PushAsync(page, animated);
    }

    public async Task PushModalAsync(Page page, bool animated = true)
    {
        await mainPageNavigation.PushModalAsync(page, animated);
    }

    public async Task PopAsync(bool animated = true)
    {
        await mainPageNavigation.PopAsync(animated);
    }

    public async Task PopModalAsync(bool animated = true)
    {
        await mainPageNavigation.PopModalAsync(animated);
    }


    public async Task PopToRootAsync(bool animated = true)
    {
        await mainPageNavigation.PopToRootAsync(animated);
    }



}

