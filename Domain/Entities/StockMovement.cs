﻿using GADistribuidora.Domain.Enums;

namespace GADistribuidora.Domain.Entities
{
    public class StockMovement : BaseClass
    {
        public int MoveQuantity { get; set; }
        public DateTime MoveDate { get; set; }
        public WarehouseLot WarehouseLot { get; set; }
        public Guid WarehouseLotId { get; set; }
        public EMovementType MovementType { get; set; }

        public StockMovement()
        {
        }
    }
}
