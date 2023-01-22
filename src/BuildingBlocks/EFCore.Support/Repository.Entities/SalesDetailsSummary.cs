using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Repository.Entities
{
    public class SalesDetailsSummary
    {
        public int Sr { get; }
        [Key]
        public string Id { get; set; }
        public string SalesId { get; set; }
        public string SalesDetailsId { get; set; }
        public string CompanyId { get; set; }
        public string BranchId { get; set; }
        public string FinancialYearId { get; set; }
        public string SlipNo { get; set; }
        public string KapanId { get; set; }
        public string ShapeId { get; set; }
        public string SizeId { get; set; }
        public string PurityId { get; set; }
        public string CharniSizeId { get; set; }
        public string GalaSizeId { get; set; }
        public string NumberSizeId { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public decimal Weight { get; set; }
        public int Category { get; set; }
        public string PurchaseId { get; set; }
        public string PurchaseDetailsId { get; set; }
        public string StockId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}
