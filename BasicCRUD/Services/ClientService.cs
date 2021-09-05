using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BasicCRUD.DataModels.Models;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;

namespace BasicCRUD.Services
{
    public class ClientService : IClientService
    {

        private readonly HttpClient _httpClient = null;

        public ClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<Product>> GetProducts()
        {
            return await _httpClient.GetJsonAsync<List<Product>>("api/product/getProducts");
        }


        public async Task<string>  SaveProduct(Product product)
        {
            StringContent data = new StringContent(JsonConvert.SerializeObject(product), Encoding.UTF8, "application/json");
            var response =  _httpClient.PostAsync("api/product/SaveProduct" , data);
            return await response.Result.Content.ReadAsStringAsync();
        }

        public async Task<string> DeleteProduct(Product product)
        {
            StringContent data = new StringContent(JsonConvert.SerializeObject(product), Encoding.UTF8, "application/json");
            var response = _httpClient.PostAsync("api/product/DeleteProduct", data);
            return await response.Result.Content.ReadAsStringAsync();
        }

    }
}
