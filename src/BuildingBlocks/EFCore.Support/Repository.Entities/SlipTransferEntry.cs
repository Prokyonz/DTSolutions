using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Entities
{
    public class SlipTransferEntry
    {
        public int Sr { get; set; }
        public int SrNo { get; set; }
        [Key]
        public string Id { get; set; }
        public string BranchId { get; set; }
        public string FinancialYearId { get; set; }
        public string Party { get; set; }
        public string PurchaseSaleId { get; set; }
        public int SlipType { get; set; }
        public DateTime SlipTransferEntryDate { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public decimal Amount { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public string Message { get; set; }
        public int ApprovalType { get; set; }
    }
}
