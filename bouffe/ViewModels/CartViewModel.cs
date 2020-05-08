using bouffe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bouffe.ViewModels
{
    public class CartViewModel
    {
        public OrderCart OrderCart { get; set; }

        public decimal OrderTotal { get; set; }
    }
}
