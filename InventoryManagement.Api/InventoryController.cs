using _01_LampshadeQuery.Contacts;
using InventoryManagement.Application.Contract.Inventory;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryQuery _inventoryQuery;
        private readonly IInventoryApplication _inventoryApplication;

        public InventoryController(IInventoryQuery inventoryQuery, IInventoryApplication inventoryApplication)
        {
            _inventoryQuery = inventoryQuery;
            _inventoryApplication = inventoryApplication;
        }

        [HttpGet("{id}")]
        public List<InventoryOperationViewModel> GetOperationsBy(Guid id)
        {
            return _inventoryApplication.GetOperationLog(id);
        }

        [HttpPost]
        public StockStatus CheckStock(IsInStock command)
        {
            return _inventoryQuery.CheckStock(command);
        }
    }
}