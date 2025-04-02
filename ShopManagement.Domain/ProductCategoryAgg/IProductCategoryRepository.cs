using System;
using _0_Framework.Domain;
using ShopManagement.Application.Contracts.ProductCategory;
using System.Collections.Generic;

namespace ShopManagement.Domain.ProductCategoryAgg
{
    public interface IProductCategoryRepository : IRepository<Guid, ProductCategory>
    {
        List<ProductCategoryViewModel> GetProductCategories();
        EditProductCategory GetDetails(Guid id);
        string GetSlugById(Guid id);
        List<ProductCategoryViewModel> Search(ProductCategorySearchModel searchModel);
    }
}
