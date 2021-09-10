using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Entities
{
    public class LessWeightMaster
    {
        public int Sr { get; }
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsDelete { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid? UpdatedBy { get; set; }

        //Navigation Properties
        public virtual List<LessWeightDetails> LessWeightDetails { get; set; }
    }
}
