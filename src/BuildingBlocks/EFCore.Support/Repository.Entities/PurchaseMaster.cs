using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Entities
{
    public class PurchaseMaster
    {
        public int Sr { get; }
        [Key]
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
        public Guid BranchId { get; set; }
        public Guid PartyId { get; set; }
        public Guid ByuerId { get; set; }
        public Guid CurrencyId { get; set; }
        public Guid FinancialYearId { get; set; }
        public Guid BrokerageId { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public decimal CurrencyRate { get; set; }
        public long PurchaseBillNo { get; set; }
        public long SlipNo { get; set; }
        public int TransactionType { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string DayName { get; set; }
        public double PartyLastBalanceWhilePurchase { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public decimal BrokerPercentage { get; set; }
        public double BrokerAmount { get; set; }
        public double RoundUpAmount { get; set; }
        public double Total { get; set; }
        public double GrossTotal { get; set; }
        public int DueDays { get; set; }
        public DateTime DueDate { get; set; }
        public int PaymentDays { get; set; }
        public int PaymentDueDays { get; set; }
        public bool IsSlip { get; set; }
        public bool IsPF { get; set; }
        public Guid CommissionToPartyId { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public decimal CommissionPercentage { get; set; }
        public double CommissionAmount { get; set; }
        public byte[] Image1 { get; set; }
        public byte[] Image2 { get; set; }
        public byte[] Image3 { get; set; }
        public bool AllowSlipPrint { get; set; }
        public bool IsTransfer { get; set; }
        public Guid TransferParentId { get; set; }
        public bool IsDelete { get; set; }
        public string Remarks { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid? UpdatedBy { get; set; }

        public List<PurchaseDetails> PurchaseDetails { get; set; }
    }
}
