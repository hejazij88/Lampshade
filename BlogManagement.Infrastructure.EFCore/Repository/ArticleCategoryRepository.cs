using _0_Framework.Application;
using _0_Framework.Infrastructure;
using BlogManagement.Application.Contract.ArticleCategory;
using BlogManagement.Domain.ArticleCategoryAgg;
using Microsoft.EntityFrameworkCore;

namespace BlogManagement.Infrastructure.EFCore.Repository;

public class ArticleCategoryRepository : RepositoryBase<Guid, ArticleCategory>, IArticleCategoryRepository
{
    private readonly BlogContext _blogContext;
    public ArticleCategoryRepository(BlogContext context) : base(context)
    {
        _blogContext = context;
    }

    public string? GetSlugBy(Guid id) => _blogContext.ArticleCategories.Select(ac => new { ac.Id, ac.Slug })
        .FirstOrDefault(ar => ar.Id == id)
        ?.Slug;

    public EditArticleCategory? GetDetails(Guid id) => _blogContext.ArticleCategories.Select(x => new EditArticleCategory
    {
        Id = x.Id,
        Name = x.Name,
        CanonicalAddress = x.CanonicalAddress,
        Description = x.Description,
        Keywords = x.Keywords,
        MetaDescription = x.MetaDescription,
        ShowOrder = x.ShowOrder,
        Slug = x.Slug,
        PictureAlt = x.PictureAlt,
        PictureTitle = x.PictureTitle
    }).FirstOrDefault(x => x.Id == id);

    public List<ArticleCategoryViewModel> GetArticleCategories()=> _blogContext.ArticleCategories.Select(x => new ArticleCategoryViewModel
    {
        Id = x.Id,
        Name = x.Name
    }).ToList();

    public List<ArticleCategoryViewModel> Search(ArticleCategorySearchModel searchModel)
    {
        var query = _blogContext.ArticleCategories
            .Include(x => x.Articles)
            .Select(x => new ArticleCategoryViewModel
            {
                Id = x.Id,
                Description = x.Description,
                Name = x.Name,
                Picture = x.Picture,
                ShowOrder = x.ShowOrder,
                CreationDate = x.CreationDate.ToFarsi(),
                ArticlesCount = x.Articles.Count
            });

        if (!string.IsNullOrWhiteSpace(searchModel.Name))
            query = query.Where(x => x.Name.Contains(searchModel.Name));

        return query.OrderByDescending(x => x.ShowOrder).ToList();
    }
}