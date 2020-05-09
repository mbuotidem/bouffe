////Adapted from https://exceptionnotfound.net/iterator-pattern-in-csharp/
using bouffe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bouffe.Interfaces
{
    public interface IPizzaIterator
    {
        Pizza First();
        Pizza Next();
        bool IsDone { get; }
        Pizza CurrentPizza { get; }
    }
}
