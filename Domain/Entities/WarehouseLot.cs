namespace GADistribuidora.Domain.Entities
{
    public class WarehouseLot : BaseClass
    {
        public Warehouse Warehouse { get; set; }
        public Guid WarehouseId { get; set; }
        public Lot Lot { get; set; }
        public Guid LotId { get; set; }
        public WarehouseLot() { }
    }
}
