using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Application.Contracts.ProductCategory;
using System.Collections.Generic;
using _0_Framework.Infrastructure;
using DiscountManagement.Contract.CustomerDiscount;

namespace ServiceHost.Areas.Administration.Pages.Discounts.CustomerDiscounts
{
    public class IndexModel : PageModel
    {
        [TempData] public string Message { get; set; }
        public CustomerDiscountSearchModel SearchModel;
        public List<CustomerDiscountViewModel> CustomerDiscountViewModels;
        public SelectList Products;

        private readonly IProductApplication _productApplication;
        private readonly ICustomerDiscountApplication _customerDiscountApplication;

        public IndexModel(IProductApplication productApplication,
            ICustomerDiscountApplication customerDiscountApplication)
        {
            _productApplication = productApplication;
            _customerDiscountApplication = customerDiscountApplication;
        }

        //[NeedsPermission(ShopPermissions.ListProducts)]
        public void OnGet(CustomerDiscountSearchModel searchModel)
        {
            Products = new SelectList(_productApplication.GetProducts(), "Id", "Name");
            CustomerDiscountViewModels = _customerDiscountApplication.Search(searchModel);
        }

        public IActionResult OnGetCreate()
        {
            var command = new DefineCustomerDiscount()
            {
                Products = _productApplication.GetProducts()
            };
            return Partial("./Create", command);
        }

        //[NeedsPermission(ShopPermissions.CreateProduct)]
        public JsonResult OnPostCreate(DefineCustomerDiscount command)
        {
            var result = _customerDiscountApplication.Define(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(Guid id)
        {
            var customerDiscount = _customerDiscountApplication.GedDetail(id);
            customerDiscount.Products = _productApplication.GetProducts();
            return Partial("Edit", customerDiscount);
        }

        //[NeedsPermission(ShopPermissions.EditProduct)]
        public JsonResult OnPostEdit(EditCustomerDiscount command)
        {
            var result = _customerDiscountApplication.Edit(command);
            return new JsonResult(result);
        }
    }
}