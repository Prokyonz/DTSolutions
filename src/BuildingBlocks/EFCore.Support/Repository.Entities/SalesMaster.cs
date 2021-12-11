using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Entities
{
    public class SalesMaster
    {
        public int Sr { get; }
        [Key]
        public string Id { get; set; }
        public string CompanyId { get; set; }
        public string BranchId { get; set; }
        public string PartyId { get; set; }
        public string SalerId { get; set; }
        public string CurrencyId { get; set; }
        public string FinancialYearId { get; set; }
        public string BrokerageId { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public decimal CurrencyRate { get; set; }
        public long SaleBillNo { get; set; }
        public long SlipNo { get; set; }
        public int TransactionType { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string DayName { get; set; }
        public double PartyLastBalanceWhileSale { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public decimal BrokerPercentage { get; set; }
        public double BrokerAmount { get; set; }
        public double RoundUpAmount { get; set; }
        public double Total { get; set; }
        public double GrossTotal { get; set; }
        public int DueDays { get; set; }
        public DateTime DueDate { get; set; }
        public int PaymentDays { get; set; }
        public DateTime PaymentDueDate { get; set; }
        public bool IsSlip { get; set; }
        public bool IsPF { get; set; }
        public string CommissionToPartyId { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public decimal CommissionPercentage { get; set; }
        public double CommissionAmount { get; set; }
        public byte[] Image1 { get; set; }
        public byte[] Image2 { get; set; }
        public byte[] Image3 { get; set; }
        public bool AllowSlipPrint { get; set; }
        public bool IsTransfer { get; set; }
        public string TransferParentId { get; set; }
        public bool IsDelete { get; set; }
        public string Remarks { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public virtual List<SalesDetails> SalesDetails { get; set; }

    }
}
