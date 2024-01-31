using GADistribuidora.Domain.Entities.ValueObjects;

namespace GADistribuidora.Domain.Entities
{
    public class Company : BaseClass
    {
        public string? Name { get; set; }
        public string? Phone { get; set; }
        public Address Address { get; set; }
        public ContactInfo ContactInfo { get; set; }
        public ICollection<User> Users { get; set; } = new List<User>();
        public Company() { }
        public Company(string name, string phone)
        {
            Name = name;
            Phone = phone;
        }
    }
}
