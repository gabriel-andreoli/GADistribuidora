using GADistribuidora.Domain.Entities.ValueObjects;

namespace GADistribuidora.Domain.Entities
{
    public class Supplier : BaseClass
    {
        public Company Company { get; set; }
        public Guid CompanyId { get; set; }
        public string? Name { get; set; }
        public Address Address { get; set; }
        public ContactInfo ContactInfo { get; set; }
        public Supplier() { }
    }
}
