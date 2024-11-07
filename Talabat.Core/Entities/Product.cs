using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.Core.Entities
{
	public class Product : BaseEntity 
	{
		// in .net 6  string  not all null but .net5 string allow null 
        public string Name { get; set; }
			public string Description { get; set; }

		public string PictureUrl { get; set; }
        public Decimal Price { get; set; }
        public int ProductBrandId { get; set; } // foreign key 
        public ProductBrand  brand { get; set; } //navgitail prop (one)


        public int ProductTypeId { get; set; } // foreign key
        public ProductType type  { get; set; } // one
    }
}
