using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Model
{
    public class Category
    {
        public int CategoryId { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        
        [MaxLength(500)]
        public string Description { get; set; }
        
        [MaxLength(255)]
        public string ImageUrl { get; set; }
        
        public bool IsActive { get; set; } = true;
        
        public int DisplayOrder { get; set; }
        
        // Navigation property
        public virtual ICollection<Product> Products { get; set; }
        
        public Category()
        {
            Products = new HashSet<Product>();
        }
    }
} 