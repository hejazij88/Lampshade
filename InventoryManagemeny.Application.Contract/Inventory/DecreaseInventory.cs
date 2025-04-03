namespace InventoryManagement.Application.Contract.Inventory
{
    public class ReduceInventory
    {
        public Guid InventoryId { get; set; }
        public Guid ProductId { get; set; }
        public long Count { get; set; }
        public string Description { get; set; }
        public Guid OrderId { get; set; }

        public ReduceInventory()
        {
            
        }

        public ReduceInventory(Guid productId, long count, string description, Guid orderId)
        {
            ProductId = productId;
            Count = count;
            Description = description;
            OrderId = orderId;
        }
    }
}
