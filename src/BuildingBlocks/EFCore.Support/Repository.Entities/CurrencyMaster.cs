using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Entities
{
    public class CurrencyMaster
    {
        public int Sr { get; }
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }

        [Column(TypeName = "decimal(18, 4)")]
        public decimal Value { get; set; }
        public bool IsDelete { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }

    }
}
