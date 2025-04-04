namespace _01_LampshadeQuery.Contacts;

public interface IProductCategoryQuery
{
    List<ProductCategoryQueryModel> GetProductCategories();
    ProductCategoryQueryModel GetProductCategoryWithProducstsBy(string slug);
    List<ProductCategoryQueryModel> GetProductCategoriesWithProducts();

}