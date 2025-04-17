using System;
using System.Collections.Generic;
using _0_Framework.Domain;
using ShopManagement.Application.Contracts.Order;

namespace ShopManagement.Domain.OrderAgg
{
    public interface IOrderRepository : IRepository<Guid, Order>
    {
        double GetAmountBy(Guid id);
        List<OrderItemViewModel> GetItems(Guid orderId);
        List<OrderViewModel> Search(OrderSearchModel searchModel);
    }
}