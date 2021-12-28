using FirstCoreApi.DataBaseModel;
using FirstCoreApi.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace FirstCoreApi.Service
{
	public class BrandService : IBrandsService
	{
		private readonly BikeStoresContext _context;

		public BrandService(BikeStoresContext context)
		{
			_context = context;
		}
		public IEnumerable<Brand> GetAlBrands()
		{
			return _context.Brands.ToList();
		}

		public Brand AddUpdateBrand(Brand brand)
		{
			try
			{
				if (brand.BrandId != 0 && _context.Brands.Any(x => x.BrandId == brand.BrandId))
				{
					var existingBrand = _context.Brands.Where(x => x.BrandId == brand.BrandId).FirstOrDefault();
					existingBrand.BrandName = brand.BrandName;
					brand = existingBrand;
				}
				else
				{
					brand.BrandId = 0;
					_context.Brands.Add(brand);
				}
				_context.SaveChanges();
				
			}
			catch 
			{
					
			}

			return brand;
		}

		public void DeleteBrand(int brandId)
		{
			try
			{
				var brand = _context.Brands.Include(e => e.Products).First(b=>b.BrandId == brandId);
				_context.Remove(brand);
				_context.SaveChanges();
			}
			catch
			{

			}
		}


	}
}
