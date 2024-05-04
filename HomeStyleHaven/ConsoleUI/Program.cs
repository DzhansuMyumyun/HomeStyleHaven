// See https://aka.ms/new-console-template for more information
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;


//SOLID
//Open Closed Principle

// Code to get all product names
    ProductManager productManager = new ProductManager(new EfProductDal());

    foreach (var product in productManager.GetAll())
    {
        Console.WriteLine(product.ProductName);
    }


    foreach (var product in productManager.GetAllByCategory(1))
    {
        Console.WriteLine(product.ProductName);
    }
