﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Grocery2Go.Models
{
    public class OrderItems
    {
        public int OrderItemsId { get; set; }        
        
        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        public virtual Order Order { get; set; } 

    }
}