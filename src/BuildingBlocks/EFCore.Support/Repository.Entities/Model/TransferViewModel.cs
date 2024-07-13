using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Repository.Entities.Model
{
    public class TransferViewModel
    {
        public string Id { get; set; }
        public string TransferMasterId { get; set; }
        public int JangadNo { get; set; }
        public DateTime? Date { get; set; }
        public string Time { get; set; }
        public string TRansferById { get; set; }
        public string CompanyId { get; set; }
        public string CharniSizeId { get; set; }
        public int FromCategory { get; set; }
        public string FromCategoryName { get; set; }
        public string BranchId { get; set; }
        public string ShapeId { get; set; }
        public decimal Carat { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public double Rate { get; set; }
        public double Amount { get; set; }
        public int ToCategory { get; set; }
        public string ToCategoryName { get; set; }
        public string ToSizeId { get; set; }
        public string ToBranchId { get; set; }
        public string ToNumberIdORKapanId { get; set; }
        public decimal ToCarat { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public double ToRate { get; set; }
        public double ToAmount { get; set; }
        public string FromNumberIdORKapanId { get; set; }
        public int Sr { get; set; }
        public int TrasnferDetailsSR { get; set; }
        public string Name { get; set; }
    }
}
