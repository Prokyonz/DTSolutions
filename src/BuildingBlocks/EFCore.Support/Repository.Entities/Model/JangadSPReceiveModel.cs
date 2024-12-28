using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Repository.Entities.Model
{
    public class JangadSPReceiveModel
    {
        public string Id { get; set; }
        public int SrNo { get; set; }
        public string JangadId { get; set; }
        public string SizeId { get; set; }
        public string Size { get; set; }
        public string PartyId { get; set; }
        public string PartyName { get; set; }
        public string BrokerId { get; set; }
        public string BrokerName { get; set; }

        [Column(TypeName = "decimal(18, 4)")]
        public double Rate { get; set; }
        public double Amount { get; set; }

        [Column(TypeName = "decimal(18, 4)")]
        public decimal TotalWeight { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public decimal AvailableWeight { get; set; }
    }
}
