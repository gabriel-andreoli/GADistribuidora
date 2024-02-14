namespace GADistribuidora.Domain.Entities
{
    public class Itinerary : BaseClass
    {
        public Vehicle Vehicle { get; set; }
        public Guid VehicleId { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan InitHour { get; set; }
        public TimeSpan EndHour { get; set; }
        public int TotalTraveled { get; set; }
        public bool Active { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public ICollection<RouteItinerary> RouteItineraries = new List<RouteItinerary>();
        public Itinerary() { }
    }
}
