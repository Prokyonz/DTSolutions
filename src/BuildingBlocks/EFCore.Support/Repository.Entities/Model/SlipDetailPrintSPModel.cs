using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Repository.Entities.Model
{
    public class SlipDetailPrintSPModel
    {
        public long Id { get; set; }
        public long SlipNo { get; set; }
        public string Date { get; set; }
        public string PartyId { get; set; }
        public string Party { get; set; }
        public string BrokerageId { get; set; }
        public string Broker { get; set; }
        public decimal Weight { get; set; }
        public decimal CVDWeight { get; set; }
        public decimal LessDiscountPercentage { get; set; }
        public decimal RejectedWeight { get; set; }
        public decimal LessWeight { get; set; }
        public decimal NetWeight { get; set; }
        public decimal CRate { get; set; }
        public decimal Disc { get; set; }
        public decimal CVDCharge { get; set; }
        public int DueDays { get; set; }
        public int PaymentDays { get; set; }
        public decimal Total { get; set; }
        public decimal Final { get; set; }
    }
}
