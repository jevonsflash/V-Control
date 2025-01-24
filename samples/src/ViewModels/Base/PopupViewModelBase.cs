using VControl.Samples.Services.Navigation;
using Size = Microsoft.Maui.Graphics.Size;

namespace VControl.Samples.ViewModels.Base
{
    public class PopupViewModelBase : ViewModelBase, IPopupViewModelBase
    {
        private readonly IDeviceDisplay deviceDisplay;

        private Size _popupSize;

        private bool _loading;

        public PopupViewModelBase(INavigationService navigationService)
            : base(navigationService)
        {
            deviceDisplay = DeviceDisplay.Current;
            deviceDisplay.MainDisplayInfoChanged += DeviceDisplay_MainDisplayInfoChanged;
            var displayInfo = deviceDisplay.MainDisplayInfo;
            SetSize(displayInfo);
        }

        public Size PopupSize
        {
            get { return _popupSize; }
            set
            {
                _popupSize = value;
                OnPropertyChanged();
            }
        }

        public bool Loading
        {
            get { return _loading; }
            set
            {
                _loading = value;
                OnPropertyChanged();
            }
        }

        protected virtual void SetSize(DisplayInfo displayInfo)
        {
            var newWidth = displayInfo.Width;
            var newHeight = displayInfo.Height * 0.8;

            var d = displayInfo.Density;
            PopupSize = new Size(newWidth / d, newHeight / d);
        }

        private void DeviceDisplay_MainDisplayInfoChanged(
            object sender,
            DisplayInfoChangedEventArgs e
        )
        {
            var displayInfo = e.DisplayInfo;
            // 新的宽度和高度
            SetSize(displayInfo);
        }
    }
}
