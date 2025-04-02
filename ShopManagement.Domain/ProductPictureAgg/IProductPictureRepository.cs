using System;
using _0_Framework.Domain;
using ShopManagement.Application.Contracts.ProductPicture;
using System.Collections.Generic;

namespace ShopManagement.Domain.ProductPictureAgg
{
    public interface IProductPictureRepository : IRepository<Guid, ProductPicture>
    {
        EditProductPicture GetDetails(Guid id);
        ProductPicture GetWithProductAndCategory(Guid id);
        List<ProductPictureViewModel> Search(ProductPictureSearchModel searchModel);
    }
}
