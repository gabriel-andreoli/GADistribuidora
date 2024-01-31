namespace GADistribuidora.Domain.Entities
{
    public class Lot : BaseClass
    {
        public DateTime ProductionDate { get; set;}
        public DateTime ExpirationDate { get; set; }
        public string Nr_Lot { get; set; }
        public Product Item { get; set; }
        public Guid ProductId { get; set; }
        public Lot() { }
    }
}
