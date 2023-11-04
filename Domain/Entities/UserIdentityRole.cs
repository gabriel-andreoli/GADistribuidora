using GADistribuidora.Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace GADistribuidora.Domain.Entities
{
    public class UserIdentityRole : IdentityRole<Guid>
    {
        public EUserRole? Role { get; set; }
    }
}
