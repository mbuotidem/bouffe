//Adapted from
//https://www.pluralsight.com/courses/building-aspdotnet-core-mvc-web-applications
using bouffe.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bouffe.Models
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }

        public virtual AMenuItem MenuItem { get; set; }

        public int Amount { get; set; }

        public string OrderId { get; set; }
    }
}
