namespace GADistribuidora.Domain.Entities
{
    public class EmployeeItinerary : BaseClass
    {
        public Itinerary Itinerary { get; set; }
        public Guid ItineraryId { get; set; }
        public Employee Employee { get; set; }
        public Guid EmployeeId { get; set; }
        public bool WasPresent { get; set; }
        public EmployeeItinerary() { }
    }
}
