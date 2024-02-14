using GADistribuidora.Domain.Enums;

namespace GADistribuidora.Domain.Entities
{
    public class Order : BaseClass
    {
        public Client Client { get; set; }
        public Guid ClientId { get; set; }
        public EOrderStatus OrderStatus { get; set; }
        public DateTime DateOfOrder { get; set; }
        public Order() { }
    }
}
