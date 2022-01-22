using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Entities
{
    public class PermissionMaster
    {
        public int Sr { get; set; }
        [Key]
        public string Id { get; set; }
        public string DisplayName { get; set; }        
        public int Category { get; set; }
        public string KeyName { get; set; }
    }
}
