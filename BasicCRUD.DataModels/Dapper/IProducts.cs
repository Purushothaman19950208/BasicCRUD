using System;
using System.Collections.Generic;
using System.Text;
using BasicCRUD.DataModels.Models;

namespace BasicCRUD.DataModels.Dapper
{
    public interface IProducts
    {
        int Add(Product product);

        List<Product> GetProductList();

        Product GetProduct(int id);

        int EditProduct(Product product);

        int DeleteProduct(int id);

        List<Category> GetCategoriesList();


    }
}
