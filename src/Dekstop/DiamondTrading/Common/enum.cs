using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiamondTrading
{
    public enum ProcessType
    {
        Send = 0,
        Receive = 1,
        Return = 2,
        Transfer = 3,
        OpeningStock = 4,
        NumberPurchase = 5
    }

    public enum ExportDataType
    {
        Excel = 0,
        PDF = 1,
        Print = 2
    }
}
