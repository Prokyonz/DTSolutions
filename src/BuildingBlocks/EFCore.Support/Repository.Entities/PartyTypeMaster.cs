using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Entities
{
    public class PartyTypeMaster
    {
        internal int Id { get; set; }
        internal string Name { get; set; }
        public static int Buyer = 0;
        public static int Seller = 0;
        public static int Broker = 0;
        public static int Other = 0;

        public static List<PartyTypeMaster> GetAllPartyType()
        {
            List<PartyTypeMaster> partyTypeMaster = new List<PartyTypeMaster>
            {
                new PartyTypeMaster {Id = Buyer, Name = "Buyer" },
                new PartyTypeMaster {Id = Seller, Name = "Seller" },
                new PartyTypeMaster {Id = Broker, Name = "Broker" },
                new PartyTypeMaster {Id = Other, Name = "Other" }
            };
            return partyTypeMaster;
        }

    }
}
