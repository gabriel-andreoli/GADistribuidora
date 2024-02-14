using System.ComponentModel;

namespace GADistribuidora.Domain.Enums
{
    public enum EMovementType
    {
        [Description("Nenhum")]
        None = 0,
        [Description("Entrada")]
        Entry = 1,
        [Description("Saída")]
        Out = 2,
    }
}
