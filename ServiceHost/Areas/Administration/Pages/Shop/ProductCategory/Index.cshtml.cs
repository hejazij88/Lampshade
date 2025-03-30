using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Contracts.ProductCategory;

namespace ServiceHost.Areas.Administration.Pages.Shop.ProductCategory
{
    public class IndexModel : PageModel
    {
        private readonly IProductCategoryApplication _productCategoryApplication;

        public List<ProductCategoryViewModel> CategoryViewModels = new();

        public ProductCategorySearchModel? CategorySearchModel;



        public IndexModel(IProductCategoryApplication productCategoryApplication)
        {
            _productCategoryApplication= productCategoryApplication;
        }
        public void OnGet(ProductCategorySearchModel searchModel)
        {
            _productCategoryApplication.Search(searchModel);
        }

        public IActionResult OnGetCreate()
        {
            return Partial("./Create", new CreateProductCategory());
        }
    }
}
