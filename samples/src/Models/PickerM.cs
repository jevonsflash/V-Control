using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VControl.Controls;
using VControl.Controls.Validations;

namespace VControl.Samples.Models
{
    public partial class PickerM : ObservableObject
    {
        [ObservableProperty]
        public string _id;

        [ObservableProperty]
        public string _value;

        [ObservableProperty]
        public string _otherValue;

        [ObservableProperty]
        public bool _isSelected;

        [ObservableProperty]
        public ICommand _delCommand;

        [ObservableProperty]
        public string _title;

        [ObservableProperty]
        public string _width;
    }
}
