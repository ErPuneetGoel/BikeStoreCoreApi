using FirstCoreApi.DataBaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstCoreApi.Interfaces
{
	public interface IBrandsService
	{
		IEnumerable<Brand> GetAlBrands();
		Brand AddUpdateBrand(Brand brand);
		void DeleteBrand(int brandId);
	}
}
