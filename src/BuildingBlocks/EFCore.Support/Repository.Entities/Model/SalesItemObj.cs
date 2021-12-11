using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Entities.Model
{
    public class SalesItemObj
    {
        public List<SalesItemDetails> KapanItemList { get; set; }
        public List<SalesItemDetails> BoilItemList { get; set; }
        public List<SalesItemDetails> CharniItemList { get; set; }
        public List<SalesItemDetails> GalaItemList { get; set; }
        public List<SalesItemDetails> NumberItemList { get; set; }
    }
}
