using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BasicCRUD.BusinessService.Services;
using BasicCRUD.DataModels.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BasicCRUD.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService = null;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        [Route("getProducts")]
        public IActionResult getProducts()
        {
            var data = _productService.getProducts();
            return Ok(data);
        }

        [HttpPost]
        [Route("SaveProduct")]
        public IActionResult SaveProduct(Product objProduct)
        {
            _productService.SaveProduct(objProduct);
            return Ok();
        }

        [HttpPost]
        [Route("DeleteProduct")]
        public IActionResult DeleteProduct(Product objProduct)
        {
            _productService.DeleteProduct(objProduct);
            return Ok();
        }
    }
}
