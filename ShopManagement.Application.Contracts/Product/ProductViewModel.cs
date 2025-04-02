using System;

namespace ShopManagement.Application.Contracts.Product
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }
        public string Picture { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Category { get; set; }
        public Guid CategoryId { get; set; }
        public string CreationDate { get; set; }
    }
}
