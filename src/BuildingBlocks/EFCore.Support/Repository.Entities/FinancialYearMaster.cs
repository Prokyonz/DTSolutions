using System;
using System.ComponentModel.DataAnnotations;

namespace Repository.Entities
{
    public class FinancialYearMaster
    {
        public int Sr { get; set; }
        [Key]
        public Guid Id { get; set; }
        public string Description { get; set; }
    }
}
