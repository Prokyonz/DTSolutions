using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Repository.Entities.Model
{
    public class SalaryReportSPModel
    {
        public string Id { get; set; }
        public string SalaryMasterId { get; set; }
        public int SrNo { get; set; }
        public int Sr { get; set; }
        public string CompanyId { get; set; }
        public string BranchId { get; set; }
        public string FinancialYearId { get; set; }
        public string FromPartyId { get; set; }
        public string FromPartyName { get; set; }
        public int SalaryMonth { get; set; }
        public DateTime SalaryMonthDateTime { get; set; }
        public int MonthDays { get; set; }
        public float Holidays { get; set; }
        public string Remarks { get; set; }
        public string ToPartyId { get; set; }
        public string ToPartyName { get; set; }

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

        [Column(TypeName = "decimal(18, 4)")]
        public decimal OTPlusHrs { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal OTPlusRate { get; set; }

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
