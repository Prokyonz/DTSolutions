using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Entities
{
    public class SalaryManager
    {
        public int Sr { get; }
        [Key]

        public Guid Id { get; set; }
        public Guid? CompanyId { get; set; }
        public Guid? BranchId { get; set; }
        public Guid PartyId { get; set; }        
        public string SalaryMonthName { get; set; }
        public DateTime SalaryMonthDateTime { get; set; }
        public int MonthDays { get; set; }
        public float Holidays { get; set; }
        public float PayDays { get; set; }
        public float OvetimeDays { get; set; }

        [Column(TypeName = "decimal(18, 4)")]
        public decimal AdvanceAmount { get; set; }

        [Column(TypeName = "decimal(18, 4)")]
        public decimal BonusAmount { get; set; }

        [Column(TypeName = "decimal(18, 4)")]
        public decimal TotalAmount { get; set; }
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
