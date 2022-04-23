using DescontroladaAPI.Infra;
using DescontroladaAPI.Interfaces;
using DescontroladaAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DescontroladaAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductBusiness _business;

        public ProductController(IProductBusiness business)
        {
            _business = business;
        }

        [HttpGet]
        public IActionResult GetProducts([FromQuery]
            int id,
            string? name,
            string? description,
            double? sellPrice,
            int? quantity,
            bool? isOrganic,
            DateTime? RegisterDate)
        {
            var result = _business.GetProducts(id, name, description, sellPrice, quantity, isOrganic, RegisterDate);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult InsertProduct([FromBody] ProductModel product)
        {
            _business.InsertProduct(product);
            return ReturnObject.Return(obj: true);
        }

        [HttpPut]
        public IActionResult UpdateProduct([FromBody] ProductModel product)
        {
            _business.UpdateProduct(product);
            return ReturnObject.Return(obj: true);
        }

        [HttpDelete]
        public IActionResult DeleteProduct([FromQuery] int id)
        {
            _business.DeleteProduct(id);
            return ReturnObject.Return(obj: true);
        }
    }
}
