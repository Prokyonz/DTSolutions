using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Entities
{    
    public class SalaryDetail
    {
        public int Sr { get; }
        [Key]
        public string Id { get; set; }
        public string SalaryMasterId { get; set; }
        public string ToPartyId { get; set; }

        [Column(TypeName = "decimal(18, 4)")]
        public decimal SalaryAmount { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal WorkingDays { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal WorkedDays { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal OverTimeHrs { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal OverTimeRateHrs { get; set; }

        [Column(TypeName = "decimal(18, 4)")]
        public decimal AdvanceAmount { get; set; }

        [Column(TypeName = "decimal(18, 4)")]
        public decimal BonusAmount { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal RoundOfAmount { get; set; }

        [Column(TypeName = "decimal(18, 4)")]
        public decimal TotalAmount { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}
