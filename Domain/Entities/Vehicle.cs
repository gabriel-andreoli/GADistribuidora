using GADistribuidora.Domain.Enums;

namespace GADistribuidora.Domain.Entities
{
    public class Vehicle : BaseClass
    {
        public string? LicensePlate { get; set; }
        public string? Model { get; set; }
        public int? YearOfManufacture { get; set; }
        public decimal? CapacityInCubicMeters { get; set; }
        public string? Brand { get; set; }
        public bool? IsBlocked { get; set; }
        public EVehicleType Type { get; set; }
        public Company? Company { get; set; }
        public Guid CompanyId { get; set; }
        public ICollection<Itinerary> Itineraries { get; set; } = new List<Itinerary>();

        public Vehicle() { }
    }
}
