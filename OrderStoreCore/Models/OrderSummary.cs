using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderStoreCore.Models
{
    public class OrderSummary
    {
        public double Notional { get; set; }
        public double NotionalUsd { get; set; }
        public double MarketPercent { get; set; }
        public double Vwap { get; set; }
        public double Volume { get; set; }
    }
}
