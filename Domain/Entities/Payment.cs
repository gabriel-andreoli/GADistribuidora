using GADistribuidora.Domain.Enums;

namespace GADistribuidora.Domain.Entities
{
    public class Payment : BaseClass
    {
        public Invoice? Invoice { get; set; }
        public Guid InvoiceId { get; set; }
        public DateTime Expiration { get; set; }
        public EPaymentType PaymentType {get; set;}
        public Payment() { }
    }
}
