using FirstCoreApi.DataBaseModel;
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
	public class BrandController : ControllerBase
	{
		private readonly IBrandsService _brandsService;
		public BrandController(IBrandsService brandsService)
		{
			_brandsService = brandsService;
		}

		// GET: api/<BrandController>
		[HttpGet]
		public IEnumerable<Brand> Get()
		{
			return _brandsService.GetAlBrands();
		}

		// GET api/<BrandController>/5
		[HttpGet("{id}")]
		public string Get(int id)
		{
			return "value";
		}

		// POST api/<BrandController>
		[HttpPost]
		public IActionResult Post([FromBody] Brand brand)
		{
			return Ok(_brandsService.AddUpdateBrand(brand));
		}

		// PUT api/<BrandController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/<BrandController>/5
		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			_brandsService.DeleteBrand(id);
			return Ok();
		}
	}
}
