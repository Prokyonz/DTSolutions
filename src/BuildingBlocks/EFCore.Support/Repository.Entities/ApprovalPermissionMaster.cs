using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Repository.Entities
{
    public class ApprovalPermissionMaster
    {
        public int Sr { get; set; }
        [Key]
        public string Id { get; set; }

        public string DisplayName { get; set; }
        public string KeyName { get; set; }
        public string UserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}
