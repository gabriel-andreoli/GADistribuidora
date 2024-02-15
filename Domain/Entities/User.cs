using GADistribuidora.Domain.Entities.ValueObjects;
using GADistribuidora.Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace GADistribuidora.Domain.Entities
{
    public class User : IdentityUser<Guid>
    {
        public EUserRole Role { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? CPF { get; set; }
        public DateTime? BornDate { get; set; }
        public string? Name { get; set; }
        public Address? Address { get; set; } = new Address();
        public ContactInfo? ContactInfo { get; set; } = new ContactInfo();
        public Company? Company { get; set; }
        public Guid CompanyId { get; set; }

        public User() { }

        public void GenerateId()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.UtcNow;
        }

        public void DeleteMe()
        {
            Deleted = true;
            UpdateMe();
        }

        public void UpdateMe() => UpdatedAt = DateTime.UtcNow;
    }
}
