using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Repository.Entities.Model
{
    public class PFReportSPModel
    {
        public string Type { get; set; }
        public string CompanyId { get; set; }
        public string FinancialYearId { get; set; }
        public string PartyId { get; set; }
        public string PartyName { get; set; }
        public string BrokerId { get; set; }
        public string BrokerName { get; set; }
        public string SizeId { get; set; }
        public string Size { get; set; }
        public string NumberId { get; set; }
        public string Number { get; set; }

        [Column(TypeName = "decimal(18, 4)")]
        public decimal Weight { get; set; }

        [Column(TypeName = "decimal(18, 4)")]
        public decimal NetWeight { get; set; }
        public double Rate { get; set; }
        public double Amount { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
