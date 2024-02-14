using System.ComponentModel;

namespace GADistribuidora.Domain.Enums
{
    public enum EOrderStatus
    {
        [Description("Aguardando pagamento")]
        WaitingPayment = 0,
        [Description("Pago")]
        Paid = 1,
        [Description("Em rota de entrega")]
        DeliveryRoute = 2,
        [Description("Entregue")]
        Delivered = 3,
        [Description("Finalizado")]
        Finished = 4
    }
}
