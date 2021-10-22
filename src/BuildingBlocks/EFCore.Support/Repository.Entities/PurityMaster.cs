using Bogus;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Entities
{
    public class PurityMaster
    {
        public int Sr { get; }
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public bool IsDelete { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

        //Property for Fake Daa
        [NotMapped]
        public static Faker<PurityMaster> FakeData { get; } = new Faker<PurityMaster>()
        .RuleFor(p => p.Id, Guid.NewGuid().ToString())
        .RuleFor(p => p.Name, f => f.Company.CompanyName())
        .RuleFor(p => p.IsDelete, false)
        .RuleFor(p => p.CreatedDate, DateTime.Now)
        .RuleFor(p => p.CreatedBy, Guid.NewGuid().ToString())
        .RuleFor(p => p.UpdatedDate, DateTime.Now)
        .RuleFor(p => p.UpdatedBy, Guid.NewGuid().ToString());
    }
}
