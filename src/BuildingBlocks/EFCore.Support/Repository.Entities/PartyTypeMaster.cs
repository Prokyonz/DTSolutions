using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Entities
{
    public class PartyTypeMaster
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static List<PartyTypeMaster> GetAllPartyType()
        {
            List<PartyTypeMaster> partyTypeMaster = new List<PartyTypeMaster>
            {
                new PartyTypeMaster {Id = 0, Name = "Buyer" },
                new PartyTypeMaster {Id = 1, Name = "Seller" },
                new PartyTypeMaster {Id = 2, Name = "Broker" },
                new PartyTypeMaster {Id = 3, Name = "Other" }
            };
            return partyTypeMaster;
        }

    }
}
