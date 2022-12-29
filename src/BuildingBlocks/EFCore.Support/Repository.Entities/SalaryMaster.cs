using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Repository.Entities
{
    public class SalaryMaster
    {
        public int Sr { get; set; }
        [Key]
        public string Id { get; set; }
        public int SrNo { get; set; }
        public string CompanyId { get; set; }
        public string BranchId { get; set; }
        public string FinancialYearId { get; set; }
        public string FromPartyId { get; set; }
        public int SalaryMonth { get; set; }
        public DateTime SalaryMonthDateTime { get; set; }
        public int MonthDays { get; set; }
        public float Holidays { get; set; }
        public string Remarks { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

        public virtual List<SalaryDetail> SalaryDetails { get; set; }
    }
}
