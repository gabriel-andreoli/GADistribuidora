using System.ComponentModel;

namespace GADistribuidora.Domain.Enums
{
    public enum EUserRole
    {
        [Description("Usuário normal")]
        Basic = 0,
        [Description("Administrador")]
        Admin = 1
    }
}
