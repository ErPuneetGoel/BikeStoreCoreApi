using FirstCoreApi.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FirstCoreApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		private readonly IProductsService _productsService;
		public ProductsController(IProductsService productsService)
		{
			_productsService = productsService;
		}

		// GET: api/<ProductsController>
		[HttpGet]
		public IEnumerable<Product> Get()
		{
			return _productsService.GetAllProducts();
		}

		// GET api/<ProductsController>/5
		[HttpGet("{id}")]
		public IEnumerable<Product> Get(int id)
		{
			return _productsService.GetAllProductsByBrandId(id);
		}

		// POST api/<ProductsController>
		[HttpPost]
		public IActionResult Post([FromBody] Product product)
		{
			return Ok(_productsService.AddUpdateProduct(product));
		}

		// PUT api/<ProductsController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/<ProductsController>/5
		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			_productsService.DeleteProduct(id);
			return Ok();
		}
	}
}
