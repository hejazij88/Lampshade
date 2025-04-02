using System;
using _0_Framework.Domain;
using ShopManagement.Application.Contracts.Product;
using System.Collections.Generic;

namespace ShopManagement.Domain.ProductAgg
{
    public interface IProductRepository : IRepository<Guid, Product>
    {
        EditProduct GetDetails(Guid id);
        Product GetProductWithCategory(Guid id);
        List<ProductViewModel> GetProducts();
        List<ProductViewModel> Search(ProductSearchModel searchModel);
    }
}
