using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Entities
{
    public class CurrencyMaster
    {
        public int Sr { get; }
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ShotName { get; set; }

        [Column(TypeName = "decimal(18, 4)")]
        public decimal Value { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public Guid? UpdatedBy { get; set; }

    }
}
