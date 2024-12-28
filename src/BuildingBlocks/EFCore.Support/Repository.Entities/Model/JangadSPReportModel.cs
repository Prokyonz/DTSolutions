using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Repository.Entities.Model
{
    public class JangadSPReportModel
    {
        public string Id { get; set; }
        public int Sr { get; set; }
        public int SrNo { get; set; }
        public string FinancialYearId { get; set; }
        public string PartyId { get; set; }
        public string PartyName { get; set; }
        public string SizeId { get; set; }
        public string SizeName { get; set; }
        public string BrokerId { get; set; }
        public string BrokerName { get; set; }

        [Column(TypeName = "decimal(18, 4)")]
        public decimal Totalcts { get; set; }

        [Column(TypeName = "decimal(18, 4)")]
        public double Rate { get; set; }

        //[Column(TypeName = "decimal(18, 4)")]
        public double Amount { get; set; }        
        public string Remarks { get; set; }
        public DateTime? UpdatedDate { get; set; }

    }

    public class JangadSPReportNewModel
    {
        public string Id { get; set; }
        public int SrNo { get; set; }
        public int Sr { get; set; }
        public int ReceivedSrNo { get; set; }
        public string FinancialYearId { get; set; }
        public string PartyId { get; set; }
        public string PartyName { get; set; }
        public string SizeId { get; set; }
        public string SizeName { get; set; }
        public string BrokerId { get; set; }
        public string BrokerName { get; set; }

        [Column(TypeName = "decimal(18, 4)")]
        public decimal? Totalcts { get; set; }

        [Column(TypeName = "decimal(18, 4)")]
        public double? Rate { get; set; }
        public double? Amount { get; set; }
        public int EntryType { get; set; }
        public string Remarks { get; set; }
        public DateTime? UpdatedDate { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public decimal? TotalctsReceived { get; set; }

        [Column(TypeName = "decimal(18, 4)")]
        public double? RateReceived { get; set; }
        public double? AmountReceived { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public decimal? TotalctsSales { get; set; }
        public double? RateSales { get; set; }
        public double? AmountSales { get; set; }
    }
}
