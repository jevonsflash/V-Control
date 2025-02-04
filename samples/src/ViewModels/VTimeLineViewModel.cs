using System.Collections.ObjectModel;
using VControl.Controls;
using VControl.Samples.Services.Navigation;

namespace VControl.Samples.ViewModels;

public partial class VTimeLineViewModel : ViewModelBase
{
    public VTimeLineViewModel(INavigationService navService)
        : base(navService)
    {
        this.PageTitle = "VTimeLineView Samples";
        var now = DateTime.Today;

        this.ProBarList1 = new ObservableCollection<ITimeLineItemModel>()
        {
            new TimeLineItemModel()
            {
                Date = now.AddDays(-2).ToString("G"),
                Title = "Event start",
                Type = TimeLineItemType.Normal,
            },
            new TimeLineItemModel()
            {
                Date = now.AddDays(-1).ToString("G"),
                Title = "Approved",
                Type = TimeLineItemType.Active,
            },
            new TimeLineItemModel()
            {
                Date = now.ToString("G"),
                Title = "Success",
                Type = TimeLineItemType.Success,
            },
        };

        this.ProBarList = new ObservableCollection<ITimeLineItemModel>()
        {
            new TimeLineItemModel()
            {
                Date = now.ToString("G"),
                Title = "Event start",
                TitleColor = Colors.Red,
                Type = TimeLineItemType.Normal,
            },
            new TimeLineItemModel()
            {
                Date = now.ToString("G"),
                Title = "Event start",
                Details = "Gary accepted merge request!! ",
                TitleColor = Colors.Green,
                Type = TimeLineItemType.Normal,
            },
        };
    }

    [ObservableProperty]
    private bool _isIndeterminate = true;

    [ObservableProperty]
    private ObservableCollection<ITimeLineItemModel> _proBarList;

    [ObservableProperty]
    private ObservableCollection<ITimeLineItemModel> _proBarList1;
}
