using System;
using System.Collections.Generic;

namespace DiamondTrade.API.Models.Request
{
    public class Calculator
    {
        public DateTime Date { get; set; }
        public string BranchId { get; set; }
        public string PartyId { get; set; }
        public string BrokerId { get; set; }
        public double NetCarat { get; set; }
        public string Note { get; set; }
        public List<SizeDetails> SizeDetails { get; set; }
    }

    public class SizeDetails
    {
        public string SizeId { get; set; }
        public double TotalCarat { get; set; }
        public List<NumberDetails>  NumberDetails { get; set; }
    }

    public class NumberDetails
    {
        public string NumberId { get; set;} 
        public double Carat { get; set;}
    }

}
