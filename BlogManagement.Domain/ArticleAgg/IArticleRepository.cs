using _0_Framework.Domain;
using BlogManagement.Application.Contract.Article;

namespace BlogManagement.Domain.ArticleAgg;

public interface IArticleRepository:IRepository<Guid,Article>
{
    EditArticle? GetDetails(Guid id);
    Article GetWithCategory(Guid id);
    List<ArticleViewModel> Search(ArticleSearchModel searchModel);
}