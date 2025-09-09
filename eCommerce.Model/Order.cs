using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Model
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public int CustomerId { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; }
        
        // Propriétés spécifiques OCP
        public string Department { get; set; }
        public string InternalRequest { get; set; }
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        
        public ICollection<OrderItem> OrderItems { get; set; }
        
        public Order()
        {
            OrderItems = new HashSet<OrderItem>();
        }
    }
}
