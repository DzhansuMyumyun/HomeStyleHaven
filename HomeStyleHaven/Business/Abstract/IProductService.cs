using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductService
    {
        List<Product> GetAll();
        List<Product> GetAllByCategory(int id);
        List<Product> GetAllByUnitPrice(decimal min, decimal max);
        
        List<ProductDetailDto> GetProductDetails();

        Product GetById(int productId);
        IResult Add(Product product);
    }
}
