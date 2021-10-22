using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Repository.Entities
{
    public class ExpenseDetails
    {
        public int Sr { get; }
        [Key]
        public string Id { get; set; }
        public string CompanyId { get; set; }
        public string BranchId { get; set; }
        public string PartyId { get; set; }
        public double Amount { get; set; }
        public string Remarks { get; set; }
        public bool IsDelete { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

        [ForeignKey("PartyId")]
        public virtual PartyMaster PartyMaster { get; set; }
    }
}
