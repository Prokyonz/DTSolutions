using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Entities.Model
{
    public class ExpenseSPModel
    {
        public string Id { get; set; }
        public int Sr { get; set; }
        public int SrNo { get; set; }
        public string CompanyId { get; set; }
        public string BranchId { get; set; }
        public string BranchName { get; set; }
        public string PartyId { get; set; }
        public string ToPartyName { get; set; }
        public string FromPartyName { get; set; }
        public int CrDrType { get; set; }
        public double Amount { get; set; }
        public string Remarks { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? EntryDate { get; set; }
    }
}

