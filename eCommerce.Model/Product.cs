using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Model
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Description { get; set; }

        [MaxLength(255)]
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public decimal CostPrice { get; set; }
        
        // Nouvelles propriétés pour OCP
        public int? CategoryId { get; set; }
        public string TechnicalSpecs { get; set; }
        public int StockQuantity { get; set; }
        public string UnitOfMeasure { get; set; }
        public bool IsActive { get; set; } = true;
        
        // Navigation property
        public virtual Category Category { get; set; }
    }
}
