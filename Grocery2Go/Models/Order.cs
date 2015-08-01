using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Grocery2Go.Models
{
    public class Order
    {
        public int OrderId { get; set; }
       

        public string UserId { get; set; }       
        [ForeignKey("UserId")] 
        public virtual ApplicationUser User { get; set; }

        public int ShoppingCartId {get; set;}
        [ForeignKey("ShoppingCartId")]
        public virtual ShoppingCart ShoppingCart { get; set; }
        
    }
}