using System;

namespace ShopManagement.Application.Contracts.ProductPicture
{
    public class EditProductPicture : CreateProductPicture
    {
        public Guid Id { get; set; }
    }
}
