﻿

//using ShopManagement.Application.Contracts.Order;

using ShopManagement.Application.Contracts.Order;

namespace _01_LampshadeQuery.Contacts
{
    public interface IProductQuery
    {
        ProductQueryModel GetProductDetails(string slug);
        List<ProductQueryModel> GetLatestArrivals();
        List<ProductQueryModel> Search(string value);
        List<CartItem> CheckInventoryStatus(List<CartItem> cartItems);
    }
}
