namespace GADistribuidora.Domain.Entities
{
    public class BusinessUnit : BaseClass
    {
        public string? Name { get; set; }
        public string? Phone { get; set; }
        public bool IsPrincipal { get; set; }
        public BusinessUnit() { }

        public BusinessUnit(Company company)
        {
            Name = company.Name;
            Phone = company.Phone;
            IsPrincipal = true;
        }
    }
}
