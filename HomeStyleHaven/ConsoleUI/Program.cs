﻿// See https://aka.ms/new-console-template for more information
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Microsoft.IdentityModel.Tokens;


//SOLID
//Open Closed Principle
//IoC

// Code to get all product names
ProductManager productManager = new ProductManager(new EfProductDal());

foreach (var product in productManager.GetProductDetails())
{
    Console.WriteLine(product.ProductName);
}


//foreach (var product in productManager.GetAllByCategory(1))
//{
//    Console.WriteLine(product.ProductName);
//}


//CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
//foreach (var category in categoryManager.GetAll())
//{
//    Console.WriteLine(category.CategoryName);
//}


