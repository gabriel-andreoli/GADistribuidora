using System.ComponentModel;

namespace GADistribuidora.Domain.Enums
{
    public enum EProductCategory
    {
        [Description("Nenhuma")]
        None = 0,
        [Description("Bebidas")]
        Drinks = 1,
        [Description("Comidas")]
        Food = 2,
    }
}
