using System;
using System.ComponentModel.DataAnnotations;

namespace Repository.Entities
{
    public class ShapeMaster
    {
        public int Sr { get; set; }
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsDelete { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid? UpdatedBy { get; set; }
    }
}
