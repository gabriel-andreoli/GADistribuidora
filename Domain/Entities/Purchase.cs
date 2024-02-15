namespace GADistribuidora.Domain.Entities
{
    public class Purchase : BaseClass
    {
        public Supplier Supplier { get; set; }
        public Guid SupplierId { get; set; }
        public DateTime Date { get; set; }
        public string NR_NF { get; set; }
        public ICollection<PurchaseProduct> PurchaseProducts { get; set; } = new List<PurchaseProduct>();
        public Purchase() { }
    }
}
