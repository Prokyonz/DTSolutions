using System;
using System.ComponentModel.DataAnnotations;

namespace Repository.Entities
{
    public class FinancialYearMaster
    {
        public int Sr { get; set; }
        [Key]
        public Guid Id { get; set; }
        public DateTime StatDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
        public bool IsDelete { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid? UpdatedBy { get; set; }
    }
}
