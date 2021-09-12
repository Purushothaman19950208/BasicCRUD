using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BasicCRUD.DataModels.Models;

namespace BasicCRUD.Services
{
    public interface IClientService
    {
        List<Product> GetProducts();
        void SaveProduct(Product product);
        void DeleteProduct(Product product);

        List<Category> GetCategories();
    }
}
