using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Layouts;
using VControl.Controls;
using VControl.Samples.Views.Base;

namespace VControl.Samples.Views;

public partial class VCheckableCollectionView : ContentPageBase<VCheckableCollectionViewModel>
{
    public VCheckableCollectionView(VCheckableCollectionViewModel viewModel)
        : base(viewModel)
    {
        InitializeComponent();
    }
}
