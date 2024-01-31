using System.ComponentModel;

namespace GADistribuidora.Domain.Enums
{
    public enum EVehicleType
    {
        [Description("Nenhum")]
        None = 0,
        [Description("Carro")]
        Car = 1,
        [Description("Motocicleta")]
        Motorcycle = 2,
        [Description("Caminhão")]
        Truck = 3,
        [Description("Ônibus")]
        Bus = 4,
        [Description("Van")]
        Van = 5
    }
}
