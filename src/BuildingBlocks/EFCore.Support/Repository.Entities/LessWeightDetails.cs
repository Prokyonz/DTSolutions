using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Repository.Entities
{
    public class LessWeightDetails
    {
        public int Sr { get; }
        [Key]
        public Guid Id { get; set; }
        public Guid LessWeightId { get; set; }
        public float MinWeight { get; set; }
        public float MaxWeight { get; set; }
        public float LessWeight { get; set; }

        [ForeignKey("LessWeightId")]
        public LessWeightMaster LessWeightMaster { get; set; }
    }
}
