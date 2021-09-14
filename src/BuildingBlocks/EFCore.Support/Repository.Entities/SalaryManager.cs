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
        public Guid UserId { get; set; }
        public Guid? BranchId { get; set; }
        public string SalaryMonthName { get; set; }
        public DateTime SalaryMonthDateTime { get; set; }
        public int MonthDays { get; set; }
        public float Holidays { get; set; }
        public float PayDays { get; set; }
        public float OvetimeDays { get; set; }

        [Column(TypeName = "decimal(18, 4)")]
        public decimal PFAmount { get; set; }

        [Column(TypeName = "decimal(18, 4)")]
        public decimal ProfessionalTaxAmount { get; set; }

        [Column(TypeName = "decimal(18, 4)")]
        public decimal AdvanceAmount { get; set; }

        [Column(TypeName = "decimal(18, 4)")]
        public decimal OtherDeductions { get; set; }

        [Column(TypeName = "decimal(18, 4)")]
        public decimal TotalAmount { get; set; }
        public string Remarks { get; set; }
        public bool IsDelete { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid? UpdatedBy { get; set; }

        //This propeties can be include in the UserMaster if the user if employee
        //public string EmployeeCode { get; set; }
        //public string DepartmentName { get; set; }
        //public string Designation { get; set; }
        //public DateTime DateOfJoin { get; set; }
        //public DateTime DateOfBirth { get; set; }
        //public string BankName { get; set; }
        //public string PFNo { get; set; }
        //public string UANNo { get; set; }

        [ForeignKey("UserId")]
        public virtual UserMaster UserMaster { get; set; }

    }
}
