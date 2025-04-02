using System;

namespace ShopManagement.Application.Contracts.Product
{
    public class EditProduct : CreateProduct
    {
        public Guid Id { get; set; }
    }
}
