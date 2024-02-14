using System.ComponentModel;

namespace GADistribuidora.Domain.Enums
{
    public enum EClientType
    {
        [Description("Pessoa Física")]
        PF = 0,
        [Description("Pessoa Jurídica")]
        PJ = 1
    }
}
