using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BasicCRUD.DataModels.Models;

namespace BasicCRUD.BusinessService.Services
{
    public class ProductService : IProductService
    {
        private readonly PracticeDBContext _practiceDBContext = null;

        public ProductService(PracticeDBContext practiceDBContext)
        {
            this._practiceDBContext = practiceDBContext;
        }
        public List<Product> getProducts()
        {
            return _practiceDBContext.Products.ToList();
        }

        public void SaveProduct(Product objProduct)
        {
            if(objProduct.Id == 0)
            {
                _practiceDBContext.Products.Add(objProduct);
                _practiceDBContext.SaveChanges();
            }
            else
            {
                UpdateProduct(objProduct);
                _practiceDBContext.SaveChanges();
            }         
        }

        public void UpdateProduct(Product objProduct)
        {
             _practiceDBContext.Products.Update(objProduct);
            _practiceDBContext.SaveChanges();
        }

        public void DeleteProduct(Product objProduct)
        {
            _practiceDBContext.Products.Remove(objProduct);
            _practiceDBContext.SaveChanges();
        }
    }
}
