﻿//Adapted from https://exceptionnotfound.net/iterator-pattern-in-csharp/
using bouffe.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bouffe.Interfaces
{
    public class ChickenCollection : IOrderItemCollection
    {
        private ArrayList items = new ArrayList();

        public IGenericIterator CreateIterator()
        {
            return new ChickenIterator(this);
        }

        //Get number of chickens in collection
        public int Count
        {
            get => items.Count;
        }

        //Class Indexer
        public IMenuItem this[int index]
        {
            get => (Chicken)items[index];
            set => items.Add(value);

        }
    }
}
