using System.Collections.ObjectModel;
using System.Windows.Input;
using VControl.Samples.Views.Base;

namespace VControl.Samples.Views;

public partial class VCardView : ContentPageBase<VCardViewModel>
{

    public VCardView(VCardViewModel viewModel) : base(viewModel)
    {
        InitializeComponent();


    }




}