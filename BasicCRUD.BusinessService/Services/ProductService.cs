using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BasicCRUD.DataModels.Dapper;
using BasicCRUD.DataModels.Models;

namespace BasicCRUD.BusinessService.Services
{
    public class ProductService : IProductService
    {
        // private readonly PracticeDBContext _practiceDBContext = null;
        private readonly IProducts _products = null;

        // constructor for DBFirstApproach
        //public ProductService(PracticeDBContext practiceDBContext)
        //{
        //    this._practiceDBContext = practiceDBContext;
        //}

        //Constructor for Dapper 
        public ProductService(IProducts products)
        {
            this._products = products;
        }

        //GetProducts for EntityFramework 
        //public List<Product> getProducts()
        //{
        //    return _practiceDBContext.Products.ToList();
        //}

        //GetProducts for Dapper 

        public List<Product> getProducts()
        {
            return _products.GetProductList();
        }

        //SaveProduct or Update Product for EntityFramework 
        //public void SaveProduct(Product objProduct)
        //{
        //    if(objProduct.Id == 0)
        //    {
        //        _practiceDBContext.Products.Add(objProduct);
        //        _practiceDBContext.SaveChanges();
        //    }
        //    else
        //    {
        //        UpdateProduct(objProduct);
        //        _practiceDBContext.SaveChanges();
        //    }         
        //}


      //  SaveProduct or Update Product for Dapper
        public void SaveProduct(Product objProduct)
        {
            if (objProduct.Id == 0)
            {
                _products.Add(objProduct);
            }
            else
            {
                _products.EditProduct(objProduct);
            }
        }

        //Update Product for EntityFramework
        //public void UpdateProduct(Product objProduct)
        //{
        //     _practiceDBContext.Products.Update(objProduct);
        //    _practiceDBContext.SaveChanges();
        //}

        //Delete Product  for EntityFramework
        //public void DeleteProduct(Product objProduct)
        //{
        //    _practiceDBContext.Products.Remove(objProduct);
        //    _practiceDBContext.SaveChanges();
        //}

       // Delete Product  for Dapper
        public void DeleteProduct(Product objProduct)
        {
            _products.DeleteProduct(objProduct.Id);
        }

        public List<Category> getCategories()
        {
            return _products.GetCategoriesList();
        }
    }
}
