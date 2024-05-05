using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        //InMemoryProductDal productDal = new InMemoryProductDal();
        //=> it's not good to new a class in a class
        //=> better to use an interface because we can use it in multiple places 

        IProductDal _productDal;

        public ProductManager(IProductDal product)
        {
            this._productDal = product;
        }

        public List<Product> GetAll()
        {
           return  _productDal.GetAll();
        }

        public List<Product> GetAllByCategory(int id)
        {
            return _productDal.GetAll(p => p.CategoryId == id);
        }

        public List<Product> GetAllByUnitPrice(decimal min, decimal max)
        {
            return _productDal.GetAll(p => p.UnitPrice <= min && p.UnitPrice <= max);
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            return _productDal.GetProductDetails();
        }
    }
}
