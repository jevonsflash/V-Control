using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VControl.Controls
{
    public class TimeLineItemModel : ITimeLineItemModel
    {
        public string Title { get; set; }

        public string Details { get; set; }

        public string Date { get; set; }

        public TimeLineItemType Type { get; set; }


        public Color TitleColor { get; set; }
    }
}
