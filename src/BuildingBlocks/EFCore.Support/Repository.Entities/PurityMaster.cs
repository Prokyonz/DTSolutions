using System;
using System.ComponentModel.DataAnnotations;

namespace Repository.Entities
{
    public class PurityMaster
    {
        public int Sr { get; set; }
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsDelete { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
    }
}
