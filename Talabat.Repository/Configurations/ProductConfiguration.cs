﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;

namespace Talabat.Repository.Configurations
{
	internal class ProductConfiguration : IEntityTypeConfiguration<Product>
	{
		public void Configure(EntityTypeBuilder<Product> builder)
		{
			builder.Property(p => p.Name).HasMaxLength(100);
			builder.Property(p => p.Price).HasColumnType("decimal(18,2)");
			builder.HasOne(p => p.brand).WithMany()
					.HasForeignKey(p => p.ProductBrandId);

			builder.HasOne(p => p.type).WithMany()
				.HasForeignKey(p => p.ProductTypeId);
		}
	}
}
