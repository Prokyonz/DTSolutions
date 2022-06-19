using System;
using System.ComponentModel.DataAnnotations;

namespace Repository.Entities
{
    public class LedgerBalanceManager
    {
        public int Sr { get; set; }
        [Key]
        public string Id { get; set; }
        public string CompanyId { get; set; }
        public string FinancialYearId { get; set; }
        public string LedgerId { get; set; }
        public decimal Balance { get; set; }
        public int TypeOfBalance { get; set; } //0 - Opening Balance, 1-Closing Balance
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}
