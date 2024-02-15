using GADistribuidora.Domain.Entities.ValueObjects;

namespace GADistribuidora.Domain.Entities
{
    public class Company : BaseClass
    {
        public string? Name { get; set; }
        public Address Address { get; set; } = new Address();
        public ContactInfo ContactInfo { get; set; } = new ContactInfo();
        public ICollection<User> Users { get; set; } = new List<User>();
        public ICollection<Client> Clients { get; set; } = new List<Client>();
        public ICollection<Warehouse> Warehouses { get; set; } = new List<Warehouse>();
        public ICollection<Product> Products { get; set; } = new List<Product>();
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
        public ICollection<Supplier> Suppliers { get; set; } = new List<Supplier>();
        public ICollection<ShippingCompany> ShippingCompanies { get; set; } = new List<ShippingCompany>();
        public ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
        public Company() { }
        public Company(string email, string name)
        { 
            ContactInfo.Email = email;
            Name = name;
        }
    }
}
