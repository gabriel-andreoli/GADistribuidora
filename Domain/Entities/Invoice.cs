namespace GADistribuidora.Domain.Entities
{
    public class Invoice : BaseClass
    {
        public ShippingCompany ShippingCompany { get; set; }
        public Guid ShippingCompanyId { get; set; }
        public ICollection<Payment> Payments { get; set; } = new List<Payment>();
        public ICollection<RouteItinerary> RouteItineraries = new List<RouteItinerary>();
        public int Number { get; set; }
        public DateTime DateOfEmission { get; set; }
        public Invoice() { }
    }
}
