using CommunityToolkit.Maui.Views;

namespace VControl.Samples.Services.Navigation
{
    public interface INavigationService
    {
        Task InitializeAsync();

        Task<Page> GetCurrentPageAsync();

        Task NavigateToAsync(string route, IDictionary<string, object> routeParameters = null);

        Task NavigateToAsync<T>(IDictionary<string, object> routeParameters = null)
            where T : ContentPage;

        Task ShowPopupAsync(Popup popupPage);

        Task HidePopupAsync(Popup popupPage);

        Task PushAsync(Page page, bool animated = true);

        Task PushModalAsync(Page page, bool animated = true);

        Task<Uri> GetCurrentUriAsync();

        Task PopAsync(bool animated = true);

        Task PopModalAsync(bool animated = true);

        Task PopToRootAsync(bool animated = true);
    }
}
