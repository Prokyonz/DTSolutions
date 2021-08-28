using System.ComponentModel.DataAnnotations;

namespace Repository.Entities
{
    public class CurrencyMaster
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public float Value { get; set; }
    }
}
