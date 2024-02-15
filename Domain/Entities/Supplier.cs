using GADistribuidora.Domain.Entities.ValueObjects;

namespace GADistribuidora.Domain.Entities
{
    public class Supplier : BaseClass
    {
        public Company Company { get; set; }
        public Guid CompanyId { get; set; }
        public string? Name { get; set; }
        public Address? Address { get; set; } = new Address();
        public ContactInfo? ContactInfo { get; set; } = new ContactInfo();
        public ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();
        public Supplier() { }
    }
}
