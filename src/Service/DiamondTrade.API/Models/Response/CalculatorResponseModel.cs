using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiamondTrade.API.Models.Response
{
    public class CalculatorResponseModel
    {
        public DateTime Date { get; set; }
        public int SrNo { get; set; }
        public string CompanyId { get; set; }
        public string FinancialYearId { get; set; }
        public string BranchId { get; set; }
        public string BranchName { get; set; }
        public string PartyId { get; set; }
        public string PartyName { get; set; }
        public string BrokerId { get; set; }
        public string BrokerName { get; set; }
        public decimal NetCarat { get; set; }
        public string Note { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public List<SizeDetails> SizeDetails { get; set; }
    }

    public class NumberDetails
    {
        public string SizeId { get; set; }
        public string NumberId { get; set; }
        public decimal Carat { get; set; }
        public decimal Rate { get; set; }
        public string NumberName { get; set; }
        public decimal Percentage { get; set; }
        public decimal Amount { get; set; }
    }

    public class SizeDetails
    {
        public string SizeId { get; set; }
        public string SizeName { get; set; }
        public decimal TotalCarat { get; set; }
        public List<NumberDetails> NumberDetails { get; set; }
    }
}
