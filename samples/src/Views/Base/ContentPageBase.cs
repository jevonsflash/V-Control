using System.Diagnostics;

namespace VControl.Samples.Views.Base;


public abstract class ContentPageBase<TViewModel> : ContentPageBase where TViewModel : ViewModelBase
{
    public ContentPageBase(TViewModel viewModel) : base(viewModel)
    {
    }

}

public abstract class ContentPageBase : ContentPage
{
    public ContentPageBase(object? viewModel = null)
    {
        HideSoftInputOnTapped = true;

        BindingContext = viewModel;

        if (string.IsNullOrWhiteSpace(Title) && GetType() != null)
        {
            Title = viewModel == null && viewModel is IViewModelBase viewModelBase ? viewModelBase.PageTitle : GetType().Name;
        }

        NavigationPage.SetBackButtonTitle(this, string.Empty);
    }




    /// <summary>
    /// 显示警告
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    public async Task AlertUnAuthoirzedAsync(string message = "")
    {
        await DisplayAlert("Alert", "You have been alerted", "OK");
    }
}
