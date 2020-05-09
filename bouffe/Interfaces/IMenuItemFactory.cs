﻿using bouffe.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bouffe.Interfaces
{
    public interface IMenuItemFactory
    {
        public abstract AMenuItem CreateMenuItem(String itemName);
    }
}
