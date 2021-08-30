using System;
using System.ComponentModel.DataAnnotations;

namespace Repository.Entities
{
    public class CurrencyMaster
    {
        public int Sr { get; set; }
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public float Value { get; set; }
    }
}
