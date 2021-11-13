using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Repository.Entities.Models
{
    public class BoilProcessReceive
    {
        public string Id { get; set; }
        public Int32 BoilNo { get; set; }
        public string KapanId { get; set; }
        public string Kapan { get; set; }
        public string SlipNo { get; set; }
        public string ShapeId { get; set; }
        public string Shape { get; set; }
        public string SizeId { get; set; }
        public string Size { get; set; }
        public string PurityId { get; set; }
        public string Purity { get; set; }
        public decimal TotalWeight { get; set; }
        public decimal AvailableWeight { get; set; }
    }
}
