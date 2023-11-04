namespace GADistribuidora.Domain.Entities
{
    public class Company : BaseClass
    {
        public string? Name { get; set; }
        public string? Phone { get; set; }
        public ICollection<User> Users { get; set; }
        public Company() { }
    }
}
