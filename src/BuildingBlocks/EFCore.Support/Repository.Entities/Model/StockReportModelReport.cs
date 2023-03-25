using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Repository.Entities.Model
{
    public class StockReportModelReport
    {
        public string KapanId { get; set; }
        public string Name { get; set; }
        public string Party { get; set; }

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

    public class StockReportMasterGrid
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public decimal TotalWeight { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public decimal Rate { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public decimal TotalAmount { get; set; }
    }

    public class NumberReportModelReport
    {
        public int Id { get; set; }
        public string OperationType { get; set; }
        public string Size { get; set; }
        public string Kapan { get; set; }
        public string Category { get; set; }

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

    }
}
