using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiamondTrade.API.Models
{
    public class ExportModel
    {
        public List<string> columnsHeaders { get; set; }
        public List<List<dynamic>> rowData { get; set; }

        public List<KeyValuePairModel> footerTotals { get; set; }
    }

    public class KeyValuePairModel
    {
        public string Key { get; set; }
        public double Value { get; set; }
    }
}
