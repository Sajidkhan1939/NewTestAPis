namespace InventoryManagementAPis.Model
{
    public class Purchase
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int Quantity { get; set; }
    }

}
