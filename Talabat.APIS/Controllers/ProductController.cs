using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.Core.Entities;
using Talabat.Core.Repositories;

namespace Talabat.APIS.Controllers
{
	// for clean code
	public class ProductController : APIBaseController
	{
		private readonly IGenericRepository<Product> _productRepo;

		public ProductController(IGenericRepository<Product> productRepo)
        {
			_productRepo = productRepo;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
		{
			var product = await	 _productRepo.GetAllAsync();
			return Ok(product);
		}
		[HttpGet("{id}")]
		public async Task <ActionResult<Product>> GetProductById(int id)
		{
			var products = await _productRepo.GetByIdAsync(id);
			return Ok(products);
		}

    }
}
