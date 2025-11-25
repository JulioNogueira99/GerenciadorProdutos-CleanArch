using GerenciadorProdutos.Application.Models;
using GerenciadorProdutos.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorProdutos.API.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductsController(IProductService service)
        {
            _service = service;
        }

        // GET api/products
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _service.GetAll();
            return Ok(products);
        }

        // GET api/products/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _service.GetById(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // POST api/products
        [HttpPost]
        public async Task<IActionResult> Post(CreateProductInputModel model)
        {
            // O Service cuida da criação e retorna o ID novo
            var id = await _service.Create(model);

            // CreatedAtAction retorna 201 Created e coloca no Header a URL para consultar o novo item
            return CreatedAtAction(nameof(GetById), new { id = id }, model);
        }
    }
}