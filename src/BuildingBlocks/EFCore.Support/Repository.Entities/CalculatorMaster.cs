using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Repository.Entities
{
    public class CalculatorMaster
    {
        public int Sr { get; }
        [Key]
        public string Id { get; set; }
        public DateTime Date { get; set; }
        public string UserId { get; set; }
        public string PartyId { get; set; }
        public string DealerId { get; set; }
        public string BranchId { get; set; }
        public string SizeId { get; set; }
        public string NumberId { get; set; }

        [Column(TypeName = "decimal(18, 4)")]
        public decimal Carat { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public decimal Rate { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public decimal Amount { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Percentage { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public bool IsDelete { get; set; }
    }
}
