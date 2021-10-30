using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Repository.Entities.Models
{
    public class KapanMapping
    {
        public DateTime Date { get; set; }
        public Int64 SlipNo { get; set; }
        public string SizeId { get; set; }
        public string Size { get; set; }
        public decimal NetWeight { get; set; }
        public decimal AvailableCts { get; set; }
        public decimal? Cts { get; set; }
        public string PurchaseID { get; set; }
        public string PurchaseDetailId { get; set; }
    }
}
