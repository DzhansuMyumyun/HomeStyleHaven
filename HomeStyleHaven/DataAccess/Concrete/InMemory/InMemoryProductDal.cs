using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;

        public InMemoryProductDal()
        {
            _products = new List<Product>
            {
                new Product{ProductId = 1, CategoryId = 1, ProductName="Name1", Description = "Description1", UnitPrice=21, UnitsInStock= 2, Url="https//test1.com" } ,
                new Product{ProductId = 2, CategoryId = 2, ProductName="Name2", Description = "Description2", UnitPrice=87, UnitsInStock= 3, Url="https//test2.com" },
                new Product{ProductId = 3, CategoryId = 3, ProductName="Name3", Description = "Description3", UnitPrice=9, UnitsInStock= 6, Url="https//test3.com" }
            };
        }

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            //LINQ = Language Integrated Query
            //Lambda
            Product productToDelete = _products.SingleOrDefault(p =>  p.ProductId == product.ProductId);

            _products.Remove(productToDelete);
        }   

        public void Update(Product product)
        {
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.Description = product.Description;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.ProductId = product.ProductId;
            productToUpdate.Url = product.Url;
            productToUpdate.UnitsInStock = product.UnitsInStock;
            productToUpdate.CategoryId = product.CategoryId;
        }

        public List<Product> GetAll()
        {
            return _products;
        }


        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }
    }
}
