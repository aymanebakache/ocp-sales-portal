using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Model
{
    public class Basket
    {
        public int BasketId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string SessionId { get; set; }
        public virtual ICollection<BasketItem> BasketItems { get; set; }
    }
}
