using System;
using System.Collections.Generic;
using System.Text;
using BasicCRUD.DataModels.Models;

namespace BasicCRUD.BusinessService.Services
{
    public interface IProductService
    {
        List<Product> getProducts();
        void SaveProduct(Product objProduct);

        void DeleteProduct(Product objProduct);

        List<Category> getCategories();
    }
}
