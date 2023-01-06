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
        public decimal OTMinusHrs { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal OTMinusRate { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal OTMinusAmount { get; set; }
        public decimal OTPlusHrs { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal OTPlusRate { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal OTPlusAmount { get; set; }

        [Column(TypeName = "decimal(18, 4)")]
        public decimal AdvanceAmount { get; set; }

        [Column(TypeName = "decimal(18, 4)")]
        public decimal BonusAmount { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal RoundOfAmount { get; set; }

        [Column(TypeName = "decimal(18, 4)")]
        public decimal TotalAmount { get; set; }
    }
}
