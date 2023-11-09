using GADistribuidora.Domain.Entities;
using GADistribuidora.Presentation.DTOs;

namespace GADistribuidora.Domain.ExtensionMethods.ApiExtension
{
    public static class UserExtension
    {
        public static UserDTO ToUserDTO(this User user)
        {
            return new UserDTO() 
            {
                Id = user.Id,
                Email = user.Email,
                Name = user.Name,
            };
        }
    }
}
