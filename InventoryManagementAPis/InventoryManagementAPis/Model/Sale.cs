﻿namespace InventoryManagementAPis.Model
{
    public class Sale
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public DateTime SaleDate { get; set; }
        public int Quantity { get; set; }
    }

}
