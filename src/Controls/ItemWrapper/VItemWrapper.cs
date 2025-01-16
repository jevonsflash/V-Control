using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace VControl.Controls
{
    public partial class VItemWrapper : ItemWrapperBase
    {

        private int _index;

        public int Index
        {
            get => _index;
            set => SetProperty(ref _index, value);
        }



        private bool _isSelected;

        public bool IsSelected
        {
            get => _isSelected;
            set => SetProperty(ref _isSelected, value);
        }


        private bool _isEnabled;

        public bool IsEnabled
        {
            get => _isEnabled;
            set => SetProperty(ref _isEnabled, value);
        }

        private bool _hasRemove;

        public bool HasRemove
        {
            get => _hasRemove;
            set => SetProperty(ref _hasRemove, value);
        }

        private bool _hasEdit;

        public bool HasEdit
        {
            get => _hasEdit;
            set => SetProperty(ref _hasEdit, value);
        }

    }
}
