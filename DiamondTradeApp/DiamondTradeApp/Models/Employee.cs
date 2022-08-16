using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace DiamondTradeApp.Models
{
    public class Employee
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }
    }

    public class VeggieModel
    {
        public string Name { get; set; }
        public string Comment { get; set; }
        public bool IsReallyAVeggie { get; set; }
        public string Image { get; set; }
        public VeggieModel()
        { }
    }

    public class GroupedVeggieModel : ObservableCollection<VeggieModel>
    {
        public string LongName { get; set; }
        public string ShortName { get; set; }
        public bool IsExpand { get; set; }
    }
}
