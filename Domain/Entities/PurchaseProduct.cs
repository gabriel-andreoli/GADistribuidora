namespace GADistribuidora.Domain.Entities
{
    public class PurchaseProduct : BaseClass
    {
        public Purchase Purchase { get; set; }
        public Guid PurchaseId { get; set; }
        public Product Product { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public PurchaseProduct() { }
    }
}
