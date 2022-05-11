using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Repository.Entities.Model
{
    public class StockReportModelReport
    {
        public string Type { get; set; }
        public string KapanId { get; set; }
        public string Kapan { get; set; }
        public string Size { get; set; }
        public string GalaNumber { get; set; }
        public string NumberId { get; set; }
        public string Number { get; set; }

        //[Column(TypeName = "decimal(18, 4)")]
        //public decimal NotMapped { get; set; }

        [Column(TypeName = "decimal(18, 4)")]
        public decimal AvailableWeight { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public decimal TotalWeight { get; set; }
    }
}
