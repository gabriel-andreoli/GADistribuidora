namespace GADistribuidora.Domain.Entities.ValueObjects
{
    public class ContactInfo
    {
        public string? AreaCode { get; set; }
        public string? Phone { get; set; }
        public string? CelPhone { get; set; }
        public string? Email { get; set; }
        public ContactInfo()
        {
        }
    }
}
