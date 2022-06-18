using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Entities.Model
{
    public class PayableReceivableSPModel
    {
        public string Type { get; set; }
        public string PartyId { get; set; }
        public string Name { get; set; }
        public double Total { get; set; }
    }
}
