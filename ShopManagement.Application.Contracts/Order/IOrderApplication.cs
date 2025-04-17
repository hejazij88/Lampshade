using System;
using System.Collections.Generic;

namespace ShopManagement.Application.Contracts.Order
{
    public interface IOrderApplication
    {
        Guid PlaceOrder(Cart cart);
        double GetAmountBy(Guid id);
        void Cancel(Guid id);
        string PaymentSucceeded(Guid orderId, Guid refId);
        List<OrderItemViewModel> GetItems(Guid orderId);
        List<OrderViewModel> Search(OrderSearchModel searchModel);
    }
}