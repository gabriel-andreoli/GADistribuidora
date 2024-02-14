using GADistribuidora.Domain.Enums;

namespace GADistribuidora.Domain.Entities
{
    public class Product : BaseClass
    {
        public Company Company { get; set; }
        public Guid CompanyId { get; set; }
        public EProductCategory ProductCategory {get; set;}
        public EUnitOfMeasurement UnitOfMeasurement { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public ICollection<ProductOrder> ProductOrders { get; set; } = new List<ProductOrder>();
        public ICollection<Lot> Lots { get; set; } = new List<Lot>();
        public Product() { }
    }
}
