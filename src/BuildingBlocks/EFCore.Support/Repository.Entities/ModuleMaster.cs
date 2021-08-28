using System.ComponentModel.DataAnnotations;

namespace Repository.Entities
{
    public class ModuleMaster
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsDetele { get; set; }

    }
}
