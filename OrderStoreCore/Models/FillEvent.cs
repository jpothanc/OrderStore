using OrderStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderStoreCore.Models
{
    public class FillEvent
    {
        public FillEvent(Fill fill, FillEventType eventType = FillEventType.New)
        {
            EventType = eventType;
            Fill = fill;
        }

        public FillEventType EventType { get; private set; }
        public Fill Fill { get; private set; }
    }

    public enum FillEventType
    {
        New,
        Cancel
    };
}
