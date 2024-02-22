using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Repository.Entities
{
    public class LoanMaster
    {
        public int Sr { get; set; }
        [Key]
        public string Id { get; set; }
        public string CompanyId { get; set; }
        public int LoanType { get; set; }
        public string PartyId { get; set; }
        public string CashBankPartyId { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Amount { get; set; }
        public int DuratonType { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string EntryTime { get; set; }        

        [Column(TypeName = "decimal(18, 2)")]
        public decimal InterestRate { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal TotalInterest { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal NetAmount { get; set; }
        public string Remarks { get; set; }
        public string EntryDate { get; set; }

        public bool IsDelete { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

    }
}
