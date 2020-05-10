# Factory

This design pattern provides an interface for creating objects but allows subclasses to alter the type of an object that will be created.


For the factory pattern, you have a creation method in a base class that does not specify what objects the individual implementations of the interface will instantiate. Below is an implementation of this pattern. 



First we have the Creator, which returns an object of type ```AMenuItem```. 

```
 public interface IMenuItemFactory
    {
        public abstract AMenuItem CreateMenuItem(String itemName);
    }
```


Then we have a Product that defines the interfaces of the objects that the factory method will create. 

```
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
```

Next, we have a ConcreteProduct that implements our Product above. It has all the properties of ```AMenuItem``` above as well as the properties shown below. 

```
public class Chicken : AMenuItem
    {
        //This constructor is for the builder pattern
        public Chicken(ChickenType chickenType)
        {
            ChickenType = chickenType;
        }

        //This constructor is for object creation via the 'new' operator
        public Chicken()
        {

        }
        
        //EF Core Entities and navigational property
        public int ChickenTypeId { get; set; }
        public ChickenType ChickenType { get; set; }
    }
```


Then we have a concrete Creator that implements our Creator above. 

```
public class ChickenFactory : IMenuItemFactory
    {
        public AMenuItem CreateMenuItem(string itemName)
        {
            var chickenType = new ChickenType { ChickenTypeId = 1, ChickenTypeName = "Wings", Description = "Delicious" };

            Chicken menuItem = null;

            switch (itemName)
            {
                case "Hotwings":
                    menuItem = new Chicken { Id = 1, Name = "Hotwings", Price = 5.99M, ShortDesc = "They're hot!", ChickenType = chickenType, ImageThumbUrl = "/images/hotwings.jpg" };
                    break;
                    
                case "PlainWings":
                    menuItem = new Chicken { Id = 1, Name = "PlainWings", Price = 5.99M, ShortDesc = "They're plain!", ChickenType = chickenType, ImageThumbUrl = "/images/plainwings.jpg" };
                    break;

            }
            return menuItem;
        }
    }
```

The key detail here is that the item returned by the concrete creator, ```menuItem```, is an instance of a Concrete Product, in this case, a ```Chicken``` object. Therefore, we could just as well have a ```PizzaFactory``` that returns ```Pizza``` objects and in the future, add future factory types to represent other items that bouffe sells. 


Using this can be as simple as below:

```
chickens = new List<IMenuItem>
{
    new ChickenFactory().CreateMenuItem("Hotwings"),
    new ChickenFactory().CreateMenuItem("PlainWings")

};

```
