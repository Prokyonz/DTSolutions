using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Repository.Entities.Model
{
    public class LedgerBalanceSPModel
    {
        public string Id { get; set; }
        public string CompanyId { get; set; }
        public string LedgerId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string SubType { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public decimal OpeningBalance { get; set; }
        public decimal ClosingBalance { get; set; }
    }
}
