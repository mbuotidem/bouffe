using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bouffe.Interfaces
{
    public interface IGenericIterator
    {
        object First();

        object Next();

        bool IsDone { get;  }

        object Current { get; }
    }
}
