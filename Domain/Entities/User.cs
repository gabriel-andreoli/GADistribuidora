using GADistribuidora.Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace GADistribuidora.Domain.Entities
{
    public class User : IdentityUser<Guid>
    {
        public EUserRole Role { get; set; }
        public bool Deleted { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public Company Company { get; set; }
        public Guid CompanyId { get; set; }

        public User() { }

        public void InitializeEntity()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTimeOffset.Now;
        }

        public void DeleteMe()
        {
            Deleted = true;
            UpdateMe();
        }

        public void UpdateMe() => UpdatedAt = DateTimeOffset.Now;
    }
}
