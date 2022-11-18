using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Entities.Model
{
    public class PaymentSPModel
    {
        public string Id { get; set; }
        public string GroupId { get; set; }
        public string FromPartyId { get; set; }
        public string ToPartyId { get; set; }
        public string FromName { get; set; }
        public string ToName { get; set; }
        public decimal Amount { get; set; }
        public string ChequeNo { get; set; }
        public DateTime? ChequeDate { get; set; }
        public string Remarks { get; set; }
        public string ApprovalType { get; set; }
        //public DateTime? UpdatedDate { get; set; }
        //public string UpdatedBy { get; set; }
        public DateTime? EntryDate { get; set; }

    }

    public class MixedSPModel
    {
        public string Id { get; set; }
        public string CompanyId { get; set; }
        public string FinancialYearId { get; set; }
        public string FromPartyId { get; set; }
        public string ToPartyId { get; set; }
        public string FromName { get; set; }
        public string ToName { get; set; }
        public double? Credit { get; set; }
        public double? Debit { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string TrType { get; set; }
        public DateTime? EntryDate { get; set; }
    }
}
