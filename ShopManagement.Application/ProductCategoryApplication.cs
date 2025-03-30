﻿using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Domain.ProductCategoryAgg;
using System.Collections.Generic;
using _0_Framework.Application;

namespace ShopManagement.Application
{
    public class ProductCategoryApplication : IProductCategoryApplication
    {
        private readonly IProductCategoryRepository _productCategoryRepostory;

        public ProductCategoryApplication(IProductCategoryRepository productCategoryRepostory)
        {
            _productCategoryRepostory = productCategoryRepostory;
        }

        public OperationResult Create(CreateProductCategory command)
        {
            var operation = new OperationResult();
            if (_productCategoryRepostory.Exists(x => x.Name == command.Name))
                return operation.Failed("");

            var slug = command.Slug.Slugify();

            var picturePath = $"{command.Slug}";

            var productCategory = new ProductCategory(command.Name, command.Description,
                "picture", command.PictureAlt, command.PictureTitle, command.Keywords,
                command.MetaDescription, slug);

            _productCategoryRepostory.Create(productCategory);
            _productCategoryRepostory.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult Edit(EditProductCategory command)
        {
            var operation = new OperationResult();
            var productCategory = _productCategoryRepostory.Get(command.Id);

            if (productCategory == null)
                return operation.Failed("");

            if (_productCategoryRepostory.Exists(x => x.Name == command.Name && x.Id != command.Id))
                return operation.Failed("");

            var slug = command.Slug.Slugify();
            
            var picturePath = $"{command.Slug}";
            
            productCategory.Edit(command.Name, command.Description, "fileName",
                command.PictureAlt, command.PictureTitle, command.Keywords,
                command.MetaDescription, slug);

            _productCategoryRepostory.SaveChanges();
            return operation.Succedded();
        }

        public EditProductCategory GetDetails(long id)
        {
            return _productCategoryRepostory.GetDetails(id);
        }

        public List<ProductCategoryViewModel> GetProductCategories()
        {
            return _productCategoryRepostory.GetProductCategories();
        }

        public List<ProductCategoryViewModel> Search(ProductCategorySearchModel searchModel)
        {
            return _productCategoryRepostory.Search(searchModel);
        }
    }
}
