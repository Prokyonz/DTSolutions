using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Repository.Entities.Model
{
    public class PurchaseSPModel
    {
        public string Id { get; set; }
        public string CompanyId { get; set; }
        public string FinancialYearId { get; set; }
        public long PurchaseBillNo { get; set; }
        public long SlipNo { get; set; }
        public DateTime? Date { get; set; }
        public string Time { get; set; }
        public string PartyId { get; set; }
        public string PartyName { get; set; }
        public string MobileNo { get; set; }
        public string BuyerId { get; set; }
        public string BuyerName { get; set; }
        public string BuyerMobileNo { get; set; }
        public string BrokerageId { get; set; }
        public string BrokerName { get; set; }
        public string BrokerMobileNo { get; set; }
        public double Total { get; set; }
        public double GrossTotal { get; set; }
        public int DueDays { get; set; }
        public DateTime? DueDate { get; set; }
        public int PaymentDays { get; set; }
        public DateTime? PaymentDueDate { get; set; }
        public bool IsPF { get; set; }
        public bool IsSlip { get; set; }
        public string UpdatedBy { get; set; }
        public string KapanId { get; set; }
        public string KapanName { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public decimal Weight { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public decimal NetWeight { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public decimal LessWeight { get; set; }
        public double RoundUpAmount { get; set; }
        public double CVDAmount { get; set; }
        public double BuyingRate { get; set; }
        public string Message { get; set; }
        public string ApprovalType { get; set; }
        public string Remarks { get; set; }

    }
}
