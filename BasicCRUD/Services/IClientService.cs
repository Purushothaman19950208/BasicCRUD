using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BasicCRUD.DataModels.Models;

namespace BasicCRUD.Services
{
    public interface IClientService
    {
        Task<List<Product>> GetProducts();
        Task<string> SaveProduct(Product product);
        Task<string> DeleteProduct(Product product);

    }
}
