﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;

namespace Talabat.Repository.Data
{
	public class StoreData :DbContext
	{
        // we want to add serivice for DInhection 
        public StoreData (DbContextOptions<StoreData> options):base(options)
        {
            
        }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			// fluentAPIS
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		}
		public DbSet<Product>  products { get; set; }
        public DbSet<ProductBrand>  productBrands { get; set; }

        public DbSet<ProductType>  productTypes { get; set; }
    }
}
