using GeekShopping.ProductApi.Data.DTOs;
using GeekShopping.ProductApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.ProductApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductRepository _repository;

        public ProductController(IProductRepository repository)
        {
            _repository = repository ?? throw new ArgumentException(nameof(repository));
        }

        [HttpGet]
        public async Task<ActionResult<ProductDTO>> FindALl()
        {
            var products = await _repository.FindAll();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> FindById(long id)
        {
            var product = await _repository.FindById(id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<ProductDTO>> Create([FromBody]ProductDTO dto)
        {
            if (dto == null) return BadRequest();
            var product = await _repository.Create(dto);
            return product;

        }   

        [HttpPut]
        public async Task<ActionResult<ProductDTO>> Update([FromBody] ProductDTO dto)
        {
            if (dto == null) return BadRequest();
            var product = await _repository.Update(dto);
            return product;

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductDTO>> Delete(long id)
        {
            var status = await _repository.Delete(id);
            return !status ? BadRequest() : Ok(status);
        }
    }
}
