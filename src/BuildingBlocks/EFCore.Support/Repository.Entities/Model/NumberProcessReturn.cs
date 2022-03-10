using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Entities.Models
{
    public class NumberProcessReturn
    {
        public string Id { get; set; }
        public string SlipNo { get; set; }
        public string KapanId { get; set; }
        public string Kapan { get; set; }
        //public Int32 BoilNo { get; set; }
        public string ShapeId { get; set; }
        public string Shape { get; set; }
        public string SizeId { get; set; }
        public string Size { get; set; }
        public string PurityId { get; set; }
        public string Purity { get; set; }
        public string CharniSizeId { get; set; }
        public string CharniSize { get; set; }
        public string NumberId { get; set; }
        public string Number { get; set; }
        public string FinancialYearId { get; set; }
        public decimal Weight { get; set; }
        public decimal AvailableWeight { get; set; }
    }
}
