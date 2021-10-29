using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Repository.Entities.Models
{
    public class KapanMapping
    {
        [Key]
        public string SlipId { get; set; }
        public string SizeId { get; set; }
        public string Size { get; set; }
        public decimal NetWeight { get; set; }
        public decimal AvailableCts { get; set; }

        public decimal Cts { get; set; }
    }
}
