using System;

namespace ShopManagement.Application.Contracts.Order
{
    public class OrderItemViewModel
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public string Product { get; set; }
        public int Count { get; set; }
        public double UnitPrice { get; set; }
        public int DiscountRate { get; set; }
        public Guid OrderId { get; set; }
    }
}