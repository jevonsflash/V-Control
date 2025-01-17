namespace VControl.Samples.ViewModels
{
    public interface IPopupContainerViewModelBase
    {
        bool PopupLoading { get; set; }

        Task CloseAllPopup();
    }
}
