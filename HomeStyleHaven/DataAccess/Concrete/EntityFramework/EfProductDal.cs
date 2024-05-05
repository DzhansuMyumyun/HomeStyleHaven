using Core.DataAccsess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTO_s;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, HomeStyleHavenContext>, IProductDal
    {
        public List<ProductDetailDto> GetProductDetails()
        {
            using (HomeStyleHavenContext context = new HomeStyleHavenContext())
            {
                var result = from p in context.Products
                             join c in context.Categories
                             on p.CategoryId equals c.CategoryId
                             select new ProductDetailDto { ProductId = p.ProductId, CategoryName = c.CategoryName, ProductName = p.ProductName, UnisInStock = p.UnitsInStock };
                return result.ToList();
            }
        }
    }
}
