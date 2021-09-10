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
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsDelete { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid? UpdatedBy { get; set; }

        //Property for Fake Daa
        [NotMapped]
        public static Faker<PurityMaster> FakeData { get; } = new Faker<PurityMaster>()
        .RuleFor(p => p.Id, Guid.NewGuid())
        .RuleFor(p => p.Name, f => f.Company.CompanyName())
        .RuleFor(p => p.IsDelete, false)
        .RuleFor(p => p.CreatedDate, DateTime.Now)
        .RuleFor(p => p.CreatedBy, Guid.NewGuid())
        .RuleFor(p => p.UpdatedDate, DateTime.Now)
        .RuleFor(p => p.UpdatedBy, Guid.NewGuid());
    }
}
