using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Repository.Entities.Model
{
    public class PurchaseSlipDetailsSPModel
    {
        public string Id { get; set; }
        public long SlipNo { get; set; }
        public string Date { get; set; }
        public string PartyId { get; set; }
        public string Party { get; set; }
        public string BrokerageId { get; set; }
        public string Broker { get; set; }
        public string FinancialYearId { get; set; }
        public bool IsSlipPrint { get; set; }
    }
}
