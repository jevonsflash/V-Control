using VControl.Samples.Services.Navigation;
using VControl.Samples.ViewModels.Base;

namespace VControl.Samples.ViewModels.Popup
{
    public abstract partial class EditPopupViewModelBase<T> : PopupViewModelBase
        where T : ObservableObject, new()
    {
        public Func<T> GetData = () => default;

        public Func<Task<T>> GetDataAsync = async () => await Task.Run(() => default(T));

        [ObservableProperty]
        private T _currentItem;

        public EditPopupViewModelBase(INavigationService navigationService)
            : base(navigationService)
        {
            this.PropertyChanged += EditPopupViewModelBase_PropertyChanged;
        }

        public event EventHandler<T> OnFinishedEdit;

        public virtual async Task Init()
        {
            Loading = true;
            await Task.Delay(300);
            await Task.Run(async () =>
                {
                    T sourceData = default;
                    if (GetData != default)
                    {
                        sourceData = GetData.Invoke();
                    }
                    if (sourceData == default)
                    {
                        if (GetDataAsync != default)
                        {
                            sourceData = await GetDataAsync.Invoke();
                        }
                    }
                    if (sourceData != default)
                    {
                        this.CurrentItem = sourceData;
                    }
                    else
                    {
                        this.CurrentItem = new T();
                    }
                })
                .ContinueWith(
                    (e) =>
                    {
                        Loading = false;
                    }
                );
        }

        public virtual void EditPopupViewModelBase_PropertyChanged(
            object sender,
            System.ComponentModel.PropertyChangedEventArgs e
        )
        {
            if (e.PropertyName == nameof(CurrentItem))
            {
                if (CurrentItem == default)
                {
                    return;
                }

                CurrentItem.PropertyChanged += CurrentItem_PropertyChanged;
            }
        }

        public virtual void CurrentItem_PropertyChanged(
            object sender,
            System.ComponentModel.PropertyChangedEventArgs e
        ) { }

        [RelayCommand]
        public virtual async Task Submit()
        {
            var result = await Validate();
            await Normalize();

            if (result)
            {
                OnFinishedEdit?.Invoke(this, this.CurrentItem);
            }
        }

        public abstract Task<bool> Validate();

        public abstract Task Normalize();
    }
}
