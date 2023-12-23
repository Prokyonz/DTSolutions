using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Repository.Entities
{
    public class PriceMaster
    {
        public int Sr { get; }
        [Key]
        public string Id { get; set; }
        public string CompanyId { get; set; }
        public string CategoryId { get; set; }
        public string SizeId { get; set; }
        public string NumberId { get; set; }

        [Column(TypeName = "decimal(18, 4)")]
        public decimal Price { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }

    public class PriceMasterMobile
    {
        private int _carat = 0;
        public int Sr { get; }
        [Key]
        public string Id { get; set; }
        public string CompanyId { get; set; }
        public string CategoryId { get; set; }
        public string SizeName { get; set; }
        public string NumberName { get; set; }

        [Column(TypeName = "decimal(18, 4)")]
        public decimal Price { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

        [NotMapped]
        public decimal Carat
        {
            get { return _carat; }
            set { value = _carat; }
        }
    }
}
