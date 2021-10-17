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
        public Guid Id { get; set; }
        public Guid? CompanyId { get; set; }
        public Guid? BranchId { get; set; }
        public Guid PartyId { get; set; }
        public double Amount { get; set; }
        public string Remarks { get; set; }
        public bool IsDelete { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid? UpdatedBy { get; set; }

        [ForeignKey("PartyId")]
        public virtual PartyMaster PartyMaster { get; set; }
    }
}
