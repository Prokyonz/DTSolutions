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
        public Guid Id { get; set; }
        public Guid? CompanyId { get; set; }
        public Guid? BranchId { get; set; }
        public string SalaryMonthName { get; set; }
        public DateTime SalaryMonthDateTime { get; set; }
        public int MonthDays { get; set; }
        public float Holidays { get; set; }
        public string Remarks { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid? UpdatedBy { get; set; }

        public virtual List<SalaryDetail> SalaryDetails { get; set; }
    }
}
