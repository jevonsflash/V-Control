namespace VControl.Samples.Models
{
    public partial class HomeViewItem : ObservableObject
    {
        [ObservableProperty]
        public string _title;

        [ObservableProperty]
        public string _icon;

        [ObservableProperty]
        public string _info;

        [ObservableProperty]
        public string _url;

        [ObservableProperty]
        public bool _isExpanded;
    }
}
