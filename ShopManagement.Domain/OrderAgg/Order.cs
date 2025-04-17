using System;
using System.Collections.Generic;
using _0_Framework.Domain;

namespace ShopManagement.Domain.OrderAgg
{
    public class Order : EntityBase
    {
        public Guid AccountId { get; private set; }
        public int PaymentMethod { get; private set; }
        public double TotalAmount { get; private set; }
        public double DiscountAmount { get; private set; }
        public double PayAmount { get; private set; }
        public bool IsPaid { get; private set; }
        public bool IsCanceled { get; private set; }
        public string IssueTrackingNo { get; private set; }
        public Guid RefId { get; private set; }
        public List<OrderItem> Items { get; private set; }

        public Order(Guid accountId, int paymentMethod, double totalAmount, double discountAmount, double payAmount)
        {
            AccountId = accountId;
            TotalAmount = totalAmount;
            DiscountAmount = discountAmount;
            PayAmount = payAmount;
            PaymentMethod = paymentMethod;
            IsPaid = false;
            IsCanceled = false;
            RefId = Guid.Empty;
            Items = new List<OrderItem>();
        }

        public void PaymentSucceeded(Guid refId)
        {
            IsPaid = true;

            if (refId != Guid.Empty)
                RefId = refId;
        }

        public void Cancel()
        {
            IsCanceled = true;
        }

        public void SetIssueTrackingNo(string number)
        {
            IssueTrackingNo = number;
        }

        public void AddItem(OrderItem item)
        {
            Items.Add(item);
        }
    }
}