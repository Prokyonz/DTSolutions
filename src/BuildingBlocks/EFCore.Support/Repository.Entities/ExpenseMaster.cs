using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Repository.Entities
{
    public class ExpenseMaster
    {
        public int Sr { get; }
        [Key]

        public string Id { get; set; }
        public string BranchId { get; set; }
        public string Name { get; set; }
        public bool IsDelete { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

        public virtual List<ExpenseDetails> ExpenseDetails { get; set; }
    }
}
