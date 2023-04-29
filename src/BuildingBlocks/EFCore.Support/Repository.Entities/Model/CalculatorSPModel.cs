using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Repository.Entities.Model
{
    public class CalculatorSPModel
    {
        public DateTime Date { get; set; }
        public int SrNo { get; set; }
        public string CompanyId { get; set; }
        public string FinancialYearId { get; set; }
        public string BranchId { get; set; }
        public string PartyId { get; set; }
        public string PartyName { get; set; }
        public string BrokerId { get; set; }
        public string BrokerName { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public decimal NetCarat { get; set; }
        public string Note { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string SizeId { get; set; }
        public string SizeName { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public decimal TotalCarat { get; set; }
        public string NumberId { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public decimal Carat { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public decimal Rate { get; set; }
        public string NumberName { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Percentage { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public decimal Amount { get; set; }
    }
}
