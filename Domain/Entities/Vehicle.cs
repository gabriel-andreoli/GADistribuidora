using GADistribuidora.Domain.Enums;

namespace GADistribuidora.Domain.Entities
{
    public class Vehicle : BaseClass
    {
        public string LicensePlate { get; set; }
        public string Model { get; set; }
        public string YearOfManufacture { get; set; }
        public string CapacityInCubicMeters { get; set; }
        public string Brand { get; set; }
        public EVehicleType Type { get; set; }
        public Company? Company { get; set; }
        public Guid CompanyId { get; set; }

        public Vehicle() { }
    }
}
