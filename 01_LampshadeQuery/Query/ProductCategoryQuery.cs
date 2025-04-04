﻿using _0_Framework.Application;
using _01_LampshadeQuery.Contacts;
using DiscountManager.Infrastructure.EFCore;
using InventoryMangement.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Infrastructure.EFCore;

namespace _01_LampshadeQuery.Query;

public class ProductCategoryQuery:IProductCategoryQuery
{
   private readonly ShopContext _shopContext;
   private readonly InventoryContext _inventoryContext;
   private readonly DiscountContext _discountContext;


    public ProductCategoryQuery(ShopContext shopContext, InventoryContext inventoryContext, DiscountContext discountContext)
    {
        _shopContext = shopContext;
        _inventoryContext = inventoryContext;
        _discountContext = discountContext;
    }

        
   public List<ProductCategoryQueryModel> GetProductCategories() =>
       _shopContext.Products.Select(pc => new ProductCategoryQueryModel
       {
           Id = pc.Id,
           Slug = pc.Slug,
           Name = pc.Name,
           Description = pc.Description,
           Keywords = pc.Keywords,
           MetaDescription = pc.MetaDescription,
           Picture = pc.Picture,
           PictureAlt = pc.PictureAlt,
           PictureTitle = pc.PictureTitle
           
       }).ToList();

   public ProductCategoryQueryModel GetProductCategoryWithProducstsBy(string slug)
   {
        var inventory = _inventoryContext.Inventory.Select(x =>
                       new { x.ProductId, x.UnitPrice }).ToList();
        var discounts = _discountContext.CustomerDiscounts
            .Where(x => x.StartDate < DateTime.Now && x.EndDate > DateTime.Now)
            .Select(x => new { x.DiscountRate, x.ProductId, x.EndDate }).ToList();

        var catetory = _shopContext.ProductCategories

            .Include(a => a.Products)
            .ThenInclude(x => x.Category)
            .Select(x => new ProductCategoryQueryModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                MetaDescription = x.MetaDescription,
                Keywords = x.Keywords,
                Slug = x.Slug,
                Products = MapProducts(x.Products)
            }).AsNoTracking().FirstOrDefault(x => x.Slug == slug);

        foreach (var product in catetory.Products)
        {
            var productInventory = inventory.FirstOrDefault(x => x.ProductId == product.Id);
            if (productInventory != null)
            {
                var price = productInventory.UnitPrice;
                product.Price = price.ToMoney();
                var discount = discounts.FirstOrDefault(x => x.ProductId == product.Id);
                if (discount != null)
                {
                    int discountRate = discount.DiscountRate;
                    product.DiscountRate = discountRate;
                    product.DiscountExpireDate = discount.EndDate.ToDiscountFormat();
                    product.HasDiscount = discountRate > 0;
                    var discountAmount = Math.Round((price * discountRate) / 100);
                    product.PriceWithDiscount = (price - discountAmount).ToMoney();
                }
            }
        }

        return catetory;
    }


   private static List<ProductQueryModel> MapProducts(List<Product> products)
   {
       return products.Select(product => new ProductQueryModel
       {
           Id = product.Id,
           Category = product.Category.Name,
           Name = product.Name,
           Picture = product.Picture,
           PictureAlt = product.PictureAlt,
           PictureTitle = product.PictureTitle,
           Slug = product.Slug
       }).ToList();
   }

    public List<ProductCategoryQueryModel> GetProductCategoriesWithProducts()
   {
       var inventory = _inventoryContext.Inventory.Select(x =>
           new { x.ProductId, x.UnitPrice }).ToList();
       var discounts = _discountContext.CustomerDiscounts
           .Where(x => x.StartDate < DateTime.Now && x.EndDate > DateTime.Now)
           .Select(x => new { x.DiscountRate, x.ProductId }).ToList();

       var categories = _shopContext.ProductCategories
           .Include(x => x.Products)
           .ThenInclude(x => x.Category)
           .Select(x => new ProductCategoryQueryModel
           {
               Id = x.Id,
               Name = x.Name,
               Products = MapProducts(x.Products)
           }).AsNoTracking().ToList();

       foreach (var category in categories)
       {
           foreach (var product in category.Products)
           {
               var productInventory = inventory.FirstOrDefault(x => x.ProductId == product.Id);
               if (productInventory != null)
               {
                   var price = productInventory.UnitPrice;
                   product.Price = price.ToMoney();
                   var discount = discounts.FirstOrDefault(x => x.ProductId == product.Id);
                   if (discount != null)
                   {
                       int discountRate = discount.DiscountRate;
                       product.DiscountRate = discountRate;
                       product.HasDiscount = discountRate > 0;
                       var discountAmount = Math.Round((price * discountRate) / 100);
                       product.PriceWithDiscount = (price - discountAmount).ToMoney();
                   }
               }
           }
       }

       return categories;
   }
}