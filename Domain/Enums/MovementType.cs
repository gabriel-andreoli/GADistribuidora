using System.ComponentModel;

namespace GADistribuidora.Domain.Enums
{
    public enum MovementType
    {
        [Description("Nenhum")]
        None = 0,
        [Description("Entrada")]
        Entry = 1,
        [Description("Saída")]
        Out = 2,
    }
}
