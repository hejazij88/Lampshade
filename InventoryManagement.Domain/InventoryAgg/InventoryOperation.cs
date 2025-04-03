namespace InventoryManagement.Domain.InventoryAgg;

public class InventoryOperation
{
    public Guid Id { get; set; }
    public bool Operation { get; set; }
    public long Count { get; set; }
    public Guid OperatorId { get; set; }
    public DateTime OperationDate { get; set; }
    public long CurrentCount { get; set; }
    public string Description { get; set; }
    public Guid OrderId { get; set; }
    public Guid InventoryId { get; set; }
    public Inventory Inventory { get; private set; }
    protected InventoryOperation() { }

    public InventoryOperation(bool operation, long count, Guid operatorId, long currentCount,
        string description, Guid orderId, Guid invetoryId)
    {
        Operation = operation;
        Count = count;
        OperatorId = operatorId;
        CurrentCount = currentCount;
        Description = description;
        OrderId = orderId;
        InventoryId = invetoryId;
        OperationDate = DateTime.Now;
    }

}