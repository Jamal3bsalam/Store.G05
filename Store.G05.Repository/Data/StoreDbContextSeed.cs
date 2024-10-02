using Store.G05.Core.Entities;
using Store.G05.Repository.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Store.G05.Repository.Data
{
    public static class StoreDbContextSeed
    {
        public async static Task SeedAsync(StoreDbContext _context)
        {
          if (_context.Brands.Count() == 0)
            {
                // brand
                //1. Read Data From Json File
                var brandData = File.ReadAllText(@"..\Store.G05.Repository\DataSeed\brands.json");
                //D:\.Net Route\Eng Ahmed Amin\07 ASP.NET Core MVC\Session 03\Store.G05\Store.G05.Repository\DataSeed\brands.json

                //2. Convert Json String To list<T>
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandData);

                //3. Seed Data To DB
                if (brands is not null && brands.Count > 0)
                {
                    await _context.Brands.AddRangeAsync(brands);
                    await _context.SaveChangesAsync();
                }
            }

          if(_context.Types.Count() == 0)
            {
                var typesData = File.ReadAllText(@"..\Store.G05.Repository\DataSeed\types.json");
                var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);

                if (types is not null  && types.Count > 0)
                {
                  await _context.Types.AddRangeAsync(types);
                  await _context.SaveChangesAsync();
                }
            }
            if (_context.Products.Count() == 0)
            {
                var productsdData = File.ReadAllText(@"..\Store.G05.Repository\DataSeed\products.json");
                var products = JsonSerializer.Deserialize<List<Product>>(productsdData);

                if (products is not null && products.Count > 0)
                {
                    await _context.Products.AddRangeAsync(products);
                    await _context.SaveChangesAsync();
                }
            }

        }
    }
}
