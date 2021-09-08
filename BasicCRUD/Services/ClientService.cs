using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BasicCRUD.DataModels.Models;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using BasicCRUD.BusinessService;
using BasicCRUD.BusinessService.Services;

namespace BasicCRUD.Services
{
    public class ClientService : IClientService
    {

        private readonly IProductService _ProductService = null;

        public ClientService(IProductService ProductService)
        {
            _ProductService = ProductService;
        }
        public List<Product> GetProducts()
        {
            return  _ProductService.getProducts();
        }


        public void SaveProduct(Product product)
        {
            _ProductService.SaveProduct(product);
        }

        public void DeleteProduct(Product product)
        {
            _ProductService.DeleteProduct(product);
        }

    }
}
