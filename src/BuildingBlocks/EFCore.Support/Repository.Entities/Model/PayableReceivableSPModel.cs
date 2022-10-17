using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Entities.Model
{
    public class PayableReceivableSPModel
    {
        public string Id { get; set; }

        public long SlipNo { get; set; }
        public DateTime? EntryDate { get; set; }
        public string Type { get; set; }
        public string PartyId { get; set; }
        public string Name { get; set; }
        public string BrokerName { get; set; }
        public double Total { get; set; }
    }
}
