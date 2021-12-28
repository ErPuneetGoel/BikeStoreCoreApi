using FirstCoreApi.DataBaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstCoreApi.Interfaces
{
	public interface IProductsService
	{
		IEnumerable<Product> GetAllProducts();
		IEnumerable<Product> GetAllProductsByBrandId(int brandId);
		Product AddUpdateProduct(Product product);
		void DeleteProduct(int productId);
	}
}
