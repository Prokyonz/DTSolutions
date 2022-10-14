using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Repository.Entities.Model
{
    public class KapanLagadReportSPModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public long SlipNo { get; set; }
        public string Party { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? NetWeight { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? Rate { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? Amount { get; set; }
        public string Category { get; set; }
        public int CategoryId { get; set; }
        public string Kapan { get; set;  }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? ProfitLossPer { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? PerCts { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? InwardAvg { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? OutwardAvg { get; set; }
        public int Records { get; set; }
        public string OperationType { get; set; }
        public string Size { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? TotalSizeGroupWeight
        { get; set; }
    }
}
