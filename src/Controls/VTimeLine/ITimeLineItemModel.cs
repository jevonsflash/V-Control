using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VControl.Controls
{
    public interface ITimeLineItemModel
    {
        string Title { get; set; }

        string Details { get; set; }

        string Date { get; set; }

        TimeLineItemType Type { get; set; }


        Color TitleColor { get; set; }
    }
}
