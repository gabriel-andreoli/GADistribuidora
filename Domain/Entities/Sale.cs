namespace GADistribuidora.Domain.Entities
{
    public class Sale : BaseClass
    {
        public Order Order { get; set; }
        public Guid OrderId { get; set; }
        public Invoice Invoice { get; set; }
        public Guid InvoiceId { get; set; }
        public DateTime DateOfSale { get; set; }

        public Sale() { }
    }
}
