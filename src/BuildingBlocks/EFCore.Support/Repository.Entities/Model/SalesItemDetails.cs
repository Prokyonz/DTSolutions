using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace Repository.Entities.Model
{
    public class SalesItemDetails
    {
        public string Id { get; set; }
        public string CompanyId { get; set; }
        //public string BranchId { get; set; }
        public string FinancialYearId { get; set; }
        public string KapanId { get; set; }
        public string Kapan { get; set; }
        public string ShapeId { get; set; }
        public string Shape { get; set; }
        public string SizeId { get; set; }
        public string Size { get; set; }
        public string PurityId { get; set; }
        public string Purity { get; set; }
        public string CharniSizeId { get; set; }
        public string CharniSize { get; set; }
        public string GalaNumberId { get; set; }
        public string GalaSize { get; set; }
        public string NumberSizeId { get; set; }
        public string NumberSize { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public decimal Weight { get; set; }

    }
}
