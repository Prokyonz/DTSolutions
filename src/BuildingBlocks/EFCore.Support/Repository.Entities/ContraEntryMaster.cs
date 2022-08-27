using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Repository.Entities
{
    public class ContraEntryMaster
    {
        public int Sr { get; set; }
        [Key]
        public string Id { get; set; }
        public string CompanyId { get; set; }
        public string BranchId { get; set; }
        public string FinancialYearId { get; set; }
        public string ToPartyId { get; set; } //Bank or Cash PartyId
        public string Remarks { get; set; }
        public bool IsDelete { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public string EntryDate { get; set; }

        public virtual List<ContraEntryDetails> ContraEntryDetails { get; set; }

    }
}
