namespace InventoryManagement.Application.Contract.Inventory
{
    public class InventorySearchModel
    {
        public Guid ProductId { get; set; }
        public bool InStock { get; set; }
    }
}
