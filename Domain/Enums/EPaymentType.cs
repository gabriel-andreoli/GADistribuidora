using System.ComponentModel;

namespace GADistribuidora.Domain.Enums
{
    public enum EPaymentType
    {
        [Description("Boleto Bancário")]
        BankPaymentSlip = 0,
        [Description("Cartão de Crédito")]
        CreditCard = 1,
        [Description("Cartão de Débito")]
        DebitCard = 2,
        [Description("PIX")]
        PIX = 3,
        [Description("TED")]
        TED = 4,
        [Description("DOC")]
        DOC = 5,
    }
}
