﻿using GADistribuidora.Domain.Entities.ValueObjects;

namespace GADistribuidora.Domain.Entities
{
    public class ShippingCompany : BaseClass
    {
        public string? Name { get; set; }
        public Address Address { get; set; }
        public ContactInfo ContactInfo { get; set; }
        public Company Company { get; set; }
        public Guid CompanyId { get; set; }
        public ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();
        public ShippingCompany() { }
    }
}
