using System;
using System.Collections.Generic;

namespace DiamondTrade.API.Models.Request
{
    public class CalculatorRequest
    {
        public DateTime Date { get; set; }
        public string BranchId { get; set; }
        public string PartyId { get; set; }
        public string BrokerId { get; set; }
        public decimal NetCarat { get; set; }

        public string Note { get; set; }

        public string UserId { get; set; }

        //public string UpdatedBy { get; set; }

        public bool IsDelete { get; set; }
        public List<SizeDetails> SizeDetails { get; set; }
    }

    public class SizeDetails
    {
        public string SizeId { get; set; }
        public decimal TotalCarat { get; set; }
        public List<NumberDetails> NumberDetails { get; set; }
    }

    public class NumberDetails
    {
        public string NumberId { get; set; }
        public decimal Carat { get; set; }
        public decimal Rate { get; set; }
        public decimal Amount { get; set; }
        public decimal Percentage { get; set; }
    }

}
