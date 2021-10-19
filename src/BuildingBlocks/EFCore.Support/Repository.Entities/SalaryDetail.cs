using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Entities
{    
    public class SalaryDetail
    {
        public int Sr { get; }
        [Key]
        public Guid Id { get; set; }
        public Guid SalaryMasterId { get; set; }
        public Guid PartyId { get; set; }                
        public float PayDays { get; set; }
        public float OvetimeDays { get; set; }

        [Column(TypeName = "decimal(18, 4)")]
        public decimal AdvanceAmount { get; set; }

        [Column(TypeName = "decimal(18, 4)")]
        public decimal BonusAmount { get; set; }

        [Column(TypeName = "decimal(18, 4)")]
        public decimal TotalAmount { get; set; }        
        
        [ForeignKey("PartyId")]
        public virtual PartyMaster PartyMaster { get; set; }

        [ForeignKey("SalaryMasterId")]
        public virtual SalaryMaster SalaryMaster { get; set; }
    }
}
