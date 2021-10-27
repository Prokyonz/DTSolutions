using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Repository.Entities
{
    public class AccountToAssortMaster
    {
        public int Sr { get; set; }
        [Key]
        public string Id { get; set; }
        public string CompanyId { get; set; }
        public string BranchId { get; set; }
        public string FinancialId { get; set; }
        public DateTime? EntryDate { get; set; }
        public int AccountToAssortType { get; set; } //Send, Receive
        public string FromParyId { get; set; }
        public string ToPartyId { get; set; }
        public string KapanId { get; set; }
        public int Department { get; set; } //0->Boil, 1->Charni, 2->Gala, 3->Nuber        
        public string Remarks { get; set; }
        public bool IsDelete { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

        [ForeignKey("CompanyId")]
        public virtual CompanyMaster CompanyMaster { get; set; }
        public virtual List<AccountToAssortDetails> AccountToAssortDetails { get; set; }

    }
}
