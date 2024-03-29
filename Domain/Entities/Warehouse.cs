﻿namespace GADistribuidora.Domain.Entities
{
    public class Warehouse : BaseClass
    {
        public string Name { get; set; }
        public Company Company { get; set; }
        public Guid CompanyId { get; set; }
        public ICollection<WarehouseLot> WarehouseLots = new List<WarehouseLot>();
        public Warehouse()
        {
        }
    }
}
