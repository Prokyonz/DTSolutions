using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Repository.Entities.Model
{
    public class OpeningStockSPModel
    {
        public string Id { get; set; }
        public int SrNo { get; set; }
        public string KapanId { get; set; }
        public string KapanName { get; set; }
        public string SizeId { get; set; }
        public string SizeName { get; set; }
        public string NumberId { get; set; }
        public string NumberName { get; set; }

        [Column(TypeName = "decimal(18, 4)")]
        public decimal TotalCts { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public decimal Rate { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public decimal Amount { get; set; }
        public string Remarks { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string FinancialYearId { get; set; }
        public string CompanyId { get; set; }
        public string BranchId { get; set; }
    }
}
