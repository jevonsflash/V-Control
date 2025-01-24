using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Shapes;
using Microsoft.Maui.Platform;
using VControl.Controls.VCalendar;
using VControl.Samples.Views.Base;

namespace VControl.Samples.Views;

public partial class VDatePickerView : ContentPageBase<VDatePickerViewModel>
{

    public VDatePickerView(VDatePickerViewModel viewModel) : base(viewModel)
    {
        InitializeComponent();

    }

    private void TextCell_Tapped(object sender, EventArgs e)
    {
        MainDatePicker.SetAll(false);
    }

    private void TextCell_Tapped_1(object sender, EventArgs e)
    {
        MainDatePicker.SetAll(true);

    }

    private void TextCell_Tapped_2(object sender, EventArgs e)
    {
        MainDatePicker.TrySetSelectedDate((sender as SwitchCell).On, DateTime.Now);
    }
    private void TextCell_Tapped_3(object sender, EventArgs e)
    {
        MainDatePicker.JumpToDate(DateTime.Now);
    }

    private void SwitchCell_OnChanged(object sender, ToggledEventArgs e)
    {
        MainDatePicker.TrySetSelectedDate((sender as SwitchCell).On, DateTime.Now);

    }
}