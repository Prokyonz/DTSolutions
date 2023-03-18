using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Repository.Entities.Model
{
    public class StockReportModelReport
    {
        //public string StockId { get; set; }
        //public int Id { get; set; }
        public string KapanId { get; set; }
        public string Name { get; set; }
        //public string SizeId { get; set; }
        //public string Size { get; set; }
        //public string PurityId { get; set; }
        //public string Purity { get; set; }
        //public string ShapeId { get; set; }
        //public string Shape { get; set; }
        //public string SlipNo { get; set; }
        //public string PurchaseMasterId { get; set; }
        //public string PurchaseDetailsId { get; set; }

        [Column(TypeName = "decimal(18, 4)")]
        public decimal InwardNetWeight { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public decimal InwardRate { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public decimal InwardAmount { get; set; }

        [Column(TypeName = "decimal(18, 4)")]
        public decimal OutwardNetWeight { get; set; }

        [Column(TypeName = "decimal(18, 4)")]
        public decimal OutwardRate { get; set; }

        [Column(TypeName = "decimal(18, 4)")]
        public decimal OutwardAmount { get; set; }

        //[Column(TypeName = "decimal(18, 4)")]
        //public decimal AvailableWeight { get; set; }
        //public string FinancialYearId { get; set; }
    }
}
