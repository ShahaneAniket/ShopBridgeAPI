using Microsoft.AspNetCore.Mvc;
using ShopBridge.Models;
using ShopBridge.Services;
using System;
using System.Net;
using System.Threading.Tasks;

namespace ShopBridgeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet("GetProducts")]
        public async Task<IActionResult> GetProducts()
        {
            try
            {
                return Ok(await _productService.GetProducts());
            }
            catch (Exception ex)
            {
                return Ok("Exception :" + ex.InnerException.Message == null ? ex.Message : ex.InnerException.Message);
            }
        }
        [HttpGet("GetProduct")]
        public async Task<IActionResult> GetProduct(int Id)
        {
            try
            {
                return Ok(await _productService.GetProduct(Id));
            }
            catch (Exception ex)
            {
                return Ok("Exception :" + ex.InnerException.Message == null ? ex.Message : ex.InnerException.Message);
            }
        }
        [HttpPost("AddProduct")]
        public async Task<IActionResult> AddProduct(Product product)
        {
            try
            {
                return Ok(await _productService.AddProduct(product));
            }
            catch (Exception ex)
            {
                return Ok("Exception :" + ex.InnerException.Message == null ? ex.Message : ex.InnerException.Message);
            }
        }
        [HttpPost("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct(Product product)
        {
            try
            {
                var resp = await _productService.UpdateProduct(product);
                return Ok(resp);
            }
            catch (Exception ex)
            {
                return Ok("Exception :" + ex.InnerException.Message == null ? ex.Message : ex.InnerException.Message);
            }
        }
        [HttpPost("DeleteProduct")]
        public async Task<IActionResult> DeleteProduct(Product product)
        {
            try
            {
                var resp = await _productService.DeleteProduct(product);
                return Ok("Product Deleted Successfully");
            }
            catch (Exception ex)
            { 
                return Ok("Exception :" + ex.InnerException == null ? ex.Message : ex.InnerException.Message);
            }
        }
    }
}
