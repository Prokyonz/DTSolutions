using System;

namespace Repository.Entities.Model
{
    public class LoanSPModel
    {
        public string Id { get; set; }
        public int Sr { get; set; }
        public string CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string LoanType { get; set; }
        public string PartyId { get; set; }
        public string PartyName { get; set; }
        public string CashBankPartyId { get; set; }
        public string CashBankName { get; set; }
        public decimal Amount { get; set; }
        public int DuratonType { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal InterestRate { get; set; }
        public decimal TotalInterest { get; set; }
        public decimal NetAmount { get; set; }
        public string Remarks { get; set; }
        public bool IsDelete { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? EntryDate { get; set; }
        public string EntryTime { get; set; }
    }
}
