using _0_Framework.Domain;
using InventoryManagement.Application.Contract.Inventory;

namespace InventoryManagement.Domain.InventoryAgg;

public interface IInventoryRepository:IRepository<Guid,Inventory>
{
    EditInventory GetDetails(Guid id);
    Inventory GetBy(Guid productId);
    List<InventoryViewModel> Search(InventorySearchModel searchModel);
    List<InventoryOperationViewModel> GetOperationLog(Guid inventoryId);
}