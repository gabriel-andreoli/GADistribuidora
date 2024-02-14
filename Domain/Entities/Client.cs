using GADistribuidora.Domain.Entities.ValueObjects;
using GADistribuidora.Domain.Enums;

namespace GADistribuidora.Domain.Entities
{
    public class Client : BaseClass
    {
        public string Name { get; set; }
        public EClientType ClientType { get; set; }
        public string IdentifierDocument { get; set; }
        public Address Address { get; set; }
        public ContactInfo ContactInfo { get; set; }
        public Company Company { get; set; }
        public Guid CompanyId { get; set; }
        public Client() { } 
    }
}
