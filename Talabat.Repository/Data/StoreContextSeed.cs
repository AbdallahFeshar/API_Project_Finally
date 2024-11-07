using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Talabat.Core.Entities;

namespace Talabat.Repository.Data
{
	public static class StoreContextSeed
	{
		public static async Task SeedAsync(StoreData context)
		{
		if(!context.productBrands.Any())
			{
				var productbrand = File.ReadAllText("../Talabat.Repository/Data/DataSeed/brands.json ");
				var brands = JsonSerializer.Deserialize<List<ProductBrand>>(productbrand);
				if (brands is not null && brands.Count > 0)
				{
					foreach (var brand in brands)
						await context.Set<ProductBrand>().AddAsync(brand);

					await context.SaveChangesAsync();
				}
				
			}


			if (!context.productTypes.Any())
			{
				var producttype = File.ReadAllText("../Talabat.Repository/Data/DataSeed/types.json ");
				var types = JsonSerializer.Deserialize<List<ProductType>>(producttype);
				if (types is not null && types.Count > 0)
				{
					foreach (var type in types)
						await context.Set<ProductType>().AddAsync(type);

					await context.SaveChangesAsync();
				}

			}

			if (!context.products.Any())
			{
				var product = File.ReadAllText("../Talabat.Repository/Data/DataSeed/products.json ");
				var products = JsonSerializer.Deserialize<List<Product>>(product);
				if (products is not null && products.Count > 0)
				{
					foreach (var item in products)
						await context.Set<Product>().AddAsync(item);

					await context.SaveChangesAsync();
				}

			}


		}
	}
}
