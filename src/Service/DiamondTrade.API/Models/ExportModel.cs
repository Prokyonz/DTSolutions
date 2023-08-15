using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiamondTrade.API.Models
{
    public class ExportModel
    {
        public List<string> columnsHeaders { get; set; }
        public List<dynamic> rowData { get; set; }
    }
}
