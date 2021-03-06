﻿//Adapted from https://exceptionnotfound.net/iterator-pattern-in-csharp/
using bouffe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bouffe.Interfaces
{
    public class PizzaCollection : IOrderItemCollection
    {
        private List<IMenuItem> items = new List<IMenuItem>();

        public IGenericIterator CreateIterator()
        {
            return new PizzaIterator(this);
        }

        //Get number of pizzas in collection
        public int Count
        {
            get => items.Count;
        }

        //Class Indexer
        public IMenuItem this[int index]
        {
            get => items[index];
            set => items.Add(value);

        }
    }
}
