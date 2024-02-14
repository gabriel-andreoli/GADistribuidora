﻿namespace GADistribuidora.Domain.Entities
{
    public class ProductOrder : BaseClass
    {
        public Product Product { get; set; }
        public Guid ProductId { get; set; }
        public Order Order { get; set; }
        public Guid OrderId { get; set; }
        public int Quantity { get; set; }
        public ProductOrder() { }
    }
}
