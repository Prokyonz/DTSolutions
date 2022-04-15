using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Repository.Entities.Model
{
    public class PriceSPModel
    {
        public string CompanyId { get; set; }
        public string SizeId { get; set; }
        public string Size { get; set; }
        public string NumberId { get; set; }
        public string Number { get; set; }

        [Column(TypeName = "decimal(18, 4)")]
        public decimal Price { get; set; }
    }
}
