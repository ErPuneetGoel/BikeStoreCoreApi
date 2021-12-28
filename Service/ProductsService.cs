using FirstCoreApi.DataBaseModel;
using FirstCoreApi.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace FirstCoreApi.Service
{
	public class ProductsService : IProductsService
	{
		private readonly BikeStoresContext _context;

		public ProductsService(BikeStoresContext context)
		{
			_context = context;
		}
		public IEnumerable<Product> GetAllProducts()
		{
			var product = _context.Products.ToList();
			//_context.Entry(product[0]).Reference(s => s.Brand).Load();
			return product;
		}

		public IEnumerable<Product> GetAllProductsByBrandId(int brandId)
		{
			return _context.Products.Where(x => x.BrandId == brandId).ToList();
		}

		public Product AddUpdateProduct(Product product)
		{
			try
			{
				if (product.BrandId == 0)
				{
					return product;
				}
				else if (product.ProductId != 0 && _context.Products.Any(x => x.ProductId == product.ProductId))
				{
					var product1 = _context.Products.Where(x => x.ProductId == product.ProductId).FirstOrDefault();
					product1.ProductName = product.ProductName;
					product1.ListPrice = product.ListPrice;
					product1.BrandId = product.BrandId;
					product1.ModelYear = product.ModelYear;

					//update paramto return
					product = product1;
				}
				else
				{
					product.ProductId = 0;
					_context.Products.Add(product);
				}
				_context.SaveChanges();
				return product;
			}
			catch
			{

			}
			return product;
		}

		public void DeleteProduct(int producId)
		{
			try
			{
				if (producId != 0)
				{
					var product = _context.Products.FirstOrDefault(x => x.ProductId == producId);
					_context.Remove(product);
					_context.SaveChanges();
				}
			}
			catch
			{

			}
		}
	}
}
