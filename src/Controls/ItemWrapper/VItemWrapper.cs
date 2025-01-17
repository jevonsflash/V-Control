namespace VControl.Controls
{
    public partial class VItemWrapper : ItemWrapperBase
    {
        private int _index;

        private bool _isSelected;

        private bool _isEnabled;

        private bool _hasRemove;

        private bool _hasEdit;

        public int Index
        {
            get => _index;
            set => SetProperty(ref _index, value);
        }

        public bool IsSelected
        {
            get => _isSelected;
            set => SetProperty(ref _isSelected, value);
        }

        public bool IsEnabled
        {
            get => _isEnabled;
            set => SetProperty(ref _isEnabled, value);
        }

        public bool HasRemove
        {
            get => _hasRemove;
            set => SetProperty(ref _hasRemove, value);
        }

        public bool HasEdit
        {
            get => _hasEdit;
            set => SetProperty(ref _hasEdit, value);
        }
    }
}
