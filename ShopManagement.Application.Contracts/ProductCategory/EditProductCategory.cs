using System;

namespace ShopManagement.Application.Contracts.ProductCategory
{
    public class EditProductCategory : CreateProductCategory
    {
        public Guid Id { get; set; }
    }
}
