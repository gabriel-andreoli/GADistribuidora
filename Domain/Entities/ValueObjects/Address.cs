namespace GADistribuidora.Domain.Entities.ValueObjects
{
    public class Address
    {
        public string? Country { get; set; }
        public string? State { get; set; }
        public string? City { get; set; }
        public string? Neighborhood { get; set; }
        public string? Street { get; set; }
        public string? BuildingNumber { get; set; }
        public string? PostalCode { get; set; }
        public string? Complement { get; set; }
    }
}
