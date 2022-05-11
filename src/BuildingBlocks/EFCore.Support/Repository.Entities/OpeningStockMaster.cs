using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Repository.Entities
{
    public class OpeningStockMaster
    {
        public int Sr { get; set; }        
        public int SrNo { get; set; }
        [Key]
        public string Id { get; set; }
        public string EntryDate { get; set; }
        public string EntryTime { get; set; }
        public int Category { get; set; }
        public string CompanyId { get; set; }
        public string BranchId { get; set; }
        public string FinancialYearId { get; set; }
        public string KapanId { get; set; }
        public string ShapeId { get; set; }
        public string SizeId { get; set; }
        public string PurityId { get; set; }
        public string NumberId { get; set; }

        [Column(TypeName = "decimal(18, 4)")]
        public decimal TotalCts { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public decimal Rate { get; set; }

        [Column(TypeName = "decimal(18, 4)")]
        public decimal Amount { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

    }
}
