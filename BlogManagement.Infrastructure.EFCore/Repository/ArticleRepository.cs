using _0_Framework.Infrastructure;
using BlogManagement.Domain.ArticleAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;
using BlogManagement.Application.Contract.Article;
using Microsoft.EntityFrameworkCore;

namespace BlogManagement.Infrastructure.EFCore.Repository
{
    public class ArticleRepository:RepositoryBase<Guid,Article>,IArticleRepository
    {
        private readonly BlogContext _blogContext;
        public ArticleRepository(BlogContext context) : base(context)
        {
            _blogContext = context;
        }

        public EditArticle? GetDetails(Guid id) => _blogContext.Articles.Select(a => new EditArticle
            {
                ArticleId = a.Id,
                CanonicalAddress = a.CanonicalAddress,
                CategoryId = a.CategoryId,
                Description = a.Description,
                Keywords = a.Keywords,
                MetaDescription = a.MetaDescription,
                PictureAlt = a.PictureAlt,
                PictureTitle = a.PictureTitle,
                PublishDate = a.PublishDate.ToFarsi(),
                ShortDescription = a.ShortDescription,
                Slug = a.Slug,
                Title = a.Title
        })
            .FirstOrDefault(a => a.ArticleId == id);

        public Article? GetWithCategory(Guid id) =>
            _blogContext.Articles.Include(a => a.Category).FirstOrDefault(a => a.Id == id);

        public List<ArticleViewModel> Search(ArticleSearchModel searchModel)
        {
            var query = _blogContext.Articles.Select(x => new ArticleViewModel
            {
                Id = x.Id,
                CategoryId = x.CategoryId,
                Category = x.Category.Name,
                Picture = x.Picture,
                PublishDate = x.PublishDate.ToFarsi(),
                ShortDescription = x.ShortDescription.Substring(0, Math.Min(x.ShortDescription.Length, 50)) + " ...",
                Title = x.Title
            });

            if (!string.IsNullOrWhiteSpace(searchModel.Title))
                query = query.Where(x => x.Title.Contains(searchModel.Title));

            if (searchModel.CategoryId > Guid.Empty)
                query = query.Where(x => x.CategoryId == searchModel.CategoryId);

            return query.OrderByDescending(x => x.Id).ToList();
        }
    }
}
