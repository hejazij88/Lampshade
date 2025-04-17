using System;

namespace ShopManagement.Application.Contracts.Order
{
    public class OrderSearchModel
    {
        public Guid AccountId { get; set; }
        public bool IsCanceled { get; set; }
    }
}