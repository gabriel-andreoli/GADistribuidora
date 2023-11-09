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
        public string Name { get; set; }
        public Company Company { get; set; }
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
