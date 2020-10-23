using MyShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.DataAccess.InMemory
{
    public class ProductCategoryRespository
    {
        ObjectCache cache = MemoryCache.Default;
        List<ProductCategory> productcategories;

        public ProductCategoryRespository()
        {
            productcategories = cache["productcategories"] as List<ProductCategory>;
            if (productcategories == null)
            {
                productcategories = new List<ProductCategory>();
            }
        }
        public void Commit()
        {
            cache["productcategories"] = productcategories;
        }
        public void Insert(ProductCategory p)
        {
            productcategories.Add(p);
        }
        public void Update(ProductCategory productcategory)
        {
            ProductCategory productCategoryToUpdate = productcategories.Find(p => p.Id == productcategory.Id);
            if (productCategoryToUpdate != null)
            {
                productCategoryToUpdate = productcategory;
            }
            else
            {
                throw new Exception("Product Category no found");
            }
        }
        public ProductCategory Find(string Id)
        {
            ProductCategory productCategory = productcategories.Find(p => p.Id == Id);
            if (productCategory != null)
            {
                return productCategory;
            }
            else
            {
                throw new Exception("Product Category no found");
            }
        }
        public IQueryable<ProductCategory> Collection()
        {
            return productcategories.AsQueryable();
        }

        public void Delete(string Id)
        {
            ProductCategory productCategoryToDelete = productcategories.Find(p => p.Id == Id);
            if (productCategoryToDelete != null)
            {
                productcategories.Remove(productCategoryToDelete);
            }
            else
            {
                throw new Exception("Product no found");
            }
        }

    }
}
