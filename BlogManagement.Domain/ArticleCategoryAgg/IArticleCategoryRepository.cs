using _0_Framework.Domain;
using BlogManagement.Application.Contract.ArticleCategory;

namespace BlogManagement.Domain.ArticleCategoryAgg;

public interface IArticleCategoryRepository:IRepository<Guid,ArticleCategory>
{
    string? GetSlugBy(Guid id);
    EditArticleCategory? GetDetails(Guid id);
    List<ArticleCategoryViewModel> GetArticleCategories();
    List<ArticleCategoryViewModel> Search(ArticleCategorySearchModel searchModel);

}