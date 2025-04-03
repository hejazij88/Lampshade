using _0_Framework.Domain;

namespace InventoryManagement.Domain.InventoryAgg;

public class Inventory:EntityBase
{
    public Guid ProductId { get; set; }
    public double UnitPrice { get; set; }
    public bool IsStock { get; set; }
    public List<InventoryOperation> Operations { get; private set; }

    public Inventory(double unitPrice,Guid productId)
    {
        ProductId = productId;
        UnitPrice = unitPrice;
        IsStock = false;
    }
    public void Edit(Guid productId, double unitPrice)
    {
        ProductId = productId;
        UnitPrice = unitPrice;
    }


    public long CalculateCurrentCount()
    {
        var plus = Operations.Where(o => o.Operation).Sum(o => o.Count);
        var minus = Operations.Where(o => !o.Operation).Sum(o => o.Count);
        return plus - minus;
    }
    public void Increase(long count, Guid operatorId, string description)
    {
        var currentCount = CalculateCurrentCount() + count;
        var operation = new InventoryOperation(true, count, operatorId, currentCount, description, Guid.Empty, Id);
        Operations.Add(operation);

        //if (currentCount > 0)
        //    InStock = true;
        //else
        //    InStock = false;

        IsStock = currentCount > 0;
    }

    public void Reduce(long count, Guid operatorId, string description, Guid orderId)
    {
        var currentCount = CalculateCurrentCount() - count;
        var operation = new InventoryOperation(false, count, operatorId, currentCount, description, orderId, Id);
        Operations.Add(operation);
        IsStock = currentCount > 0;
    }
}