using System;

namespace ShopManagement.Domain.Services
{
    public interface IShopAccountAcl
    {
        (string name, string mobile) GetAccountBy(Guid id);
    }
}
