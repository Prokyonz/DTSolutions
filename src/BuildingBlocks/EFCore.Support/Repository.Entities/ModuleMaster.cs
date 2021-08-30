using System;
using System.ComponentModel.DataAnnotations;

namespace Repository.Entities
{
    public class ModuleMaster
    {
        public int Sr { get; set; }
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsDetele { get; set; }

    }
}
