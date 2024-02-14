namespace GADistribuidora.Domain.Entities
{
    public class RouteItinerary : BaseClass
    {
        public Itinerary Itinerary { get; set; }
        public Guid ItineraryId { get; set; }
        public Invoice Invoice { get; set; }
        public Guid InvoiceId { get; set; }
        public bool IsConcluded { get; set; }
        public string Observations { get; set; }
        public RouteItinerary() { }
    }
}
