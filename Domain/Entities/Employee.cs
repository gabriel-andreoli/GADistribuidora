using GADistribuidora.Domain.Entities.ValueObjects;
using GADistribuidora.Domain.Enums;

namespace GADistribuidora.Domain.Entities
{
    public class Employee : BaseClass
    {
        public Company Company { get; set; }
        public Guid CompanyId { get; set; }
        public EUserRole Role { get; set; }
        public string? Name { get; set; }
        public DateTime? BornDate { get; set; }
        public bool IsCLT { get; set; }
        public string PIS { get; set; }
        public Address Address { get; set; }
        public ContactInfo ContactInfo { get; set; }
        public ICollection<RouteItinerary> RouteItineraries = new List<RouteItinerary>();
        public Employee() { }
    }
}
