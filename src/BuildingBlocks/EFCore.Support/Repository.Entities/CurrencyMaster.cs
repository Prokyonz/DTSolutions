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
        public string Details { get; set; }

        [Column(TypeName = "decimal(18, 4)")]
        public decimal Value { get; set; }
    }
}
