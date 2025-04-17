namespace _01_LampshadeQuery.Contacts
{
    public interface IInventoryQuery
    {
        StockStatus CheckStock(IsInStock command);
    }
}
