﻿using _0_Framework.Application;
using BlogManagement.Domain.ArticleAgg;
using BlogManagement.Domain.ArticleCategoryAgg;
using System;
using System.Collections.Generic;
using BlogManagement.Application.Contract.Article;

namespace BlogManagement.Application
{
    public class ArticleApplication : IArticleApplication
    {
        private readonly IFileUploader _fileUploader;
        private readonly IArticleRepository _articleRepository;
        private readonly IArticleCategoryRepository _articleCategoryRepository;
        public ArticleApplication(IArticleRepository articleRepository, IFileUploader fileUploader,
            IArticleCategoryRepository articleCategoryRepository)
        {
            _fileUploader = fileUploader;
            _articleRepository = articleRepository;
            _articleCategoryRepository = articleCategoryRepository;
        }

        public OperationResult Create(CreateArticle command)
        {
            var operation = new OperationResult();
            if (_articleRepository.Exists(x => x.Title == command.Title))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var slug = command.Slug.Slugify();
            var categorySlug = _articleCategoryRepository.GetSlugBy(command.CategoryId);
            var path = $"{categorySlug}/{slug}";
            var pictureName = _fileUploader.Upload(command.Picture, path);
            var publishDate = command.PublishDate.ToGeorgianDateTime();

            var article = new Article(command.Title, command.ShortDescription, command.Description, pictureName,
                command.PictureAlt, command.PictureTitle, publishDate, slug, command.Keywords, command.MetaDescription,
                command.CanonicalAddress, command.CategoryId);

            _articleRepository.Create(article);
            _articleRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult Edit(EditArticle command)
        {
            var operation = new OperationResult();
            var article = _articleRepository.GetWithCategory(command.ArticleId);

            if (article == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (_articleRepository.Exists(x => x.Title == command.Title && x.Id != command.ArticleId))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var slug = command.Slug.Slugify();
            var path = $"{article.Category.Slug}/{slug}";
            var pictureName = _fileUploader.Upload(command.Picture, path);
            var publishDate = command.PublishDate.ToGeorgianDateTime();

            article.Edit(command.Title, command.ShortDescription, command.Description, pictureName,
                command.PictureAlt, command.PictureTitle, publishDate, slug, command.Keywords, command.MetaDescription,
                command.CanonicalAddress, command.CategoryId);

            _articleRepository.SaveChanges();
            return operation.Succedded();
        }

        public EditArticle GetDetails(Guid id)
        {
            return _articleRepository.GetDetails(id);
        }

        public List<ArticleViewModel> Search(ArticleSearchModel searchModel)
        {
            return _articleRepository.Search(searchModel);
        }
    }
}
