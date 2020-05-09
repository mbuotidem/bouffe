//Adapted from
//https://www.pluralsight.com/courses/building-aspdotnet-core-mvc-web-applications
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bouffe.Interfaces
{
    //This abstract class was created because Entity Framework, our ORM of choice
    //does not support interfaces
    //https://stackoverflow.com/questions/25385161/entity-framework-6-using-interface-as-navigation-properties-possible/25427142#25427142
    public abstract class AMenuItem : IMenuItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortDesc { get; set; }
        public string LongDesc { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string ImageThumbUrl { get; set; }
        public bool InStock { get; set; }
    }
}
