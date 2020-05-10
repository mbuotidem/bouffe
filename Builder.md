# Builder

This design pattern lets you construct complex objects one step at a time. It is often used when object creation involves more than just simply calling a constructor.
Another use case is when an object requires several constructors, some of which may be optional. Using a builder in this situation makes for simpler and easier to understand code. 

The first participant is a Builder interface that specifies methods to create different parts of the Product object. 

```
 abstract class MenuItemBuilder
    {
        protected IMenuItem menuItem;


        public abstract AMenuItem GetMenuItem();
        
        public abstract void AddName();
        public abstract void AddPrice();
        public abstract void AddShortDesc();
        public abstract void AddImageThumbUrl();
        public abstract void build();

        

    }
```

Then we have one or more Concrete Builder classes which follow the Builder interface and implement variations of the Product. 
In our case, that we have ```HotWingsBuilder```. Since our ```Chicken``` object requires an associated ```ChickenType``` object, 
its creation is a smidge more complicated than the creation of an object that would not need that. 

```
 class HotWingsBuilder : MenuItemBuilder
    {
        
        public HotWingsBuilder()
        {
            ChickenType chickenType = new ChickenType { ChickenTypeId = 1, ChickenTypeName = "Wings", Description = "Delicious" };
            menuItem = new Chicken(chickenType);
            menuItem.Id = chickenType.ChickenTypeId;
        }

        public override void AddImageThumbUrl()
        {
            menuItem.ImageThumbUrl = "/images/hotwings.jpg";
        }

        public override void AddName()
        {
            menuItem.Name = "HotWings";
        }

        public override void AddPrice()
        {
            menuItem.Price = 5.99M;
        }

        public override void AddShortDesc()
        {
            menuItem.ShortDesc = "They're hot!";
        }

        public override void build()
        {
            this.AddImageThumbUrl();
            this.AddName();
            this.AddPrice();
            this.AddShortDesc();
        }
        public void Reset()
        {
            this.menuItem = new Chicken();
        }

        public override AMenuItem GetMenuItem()
        {
            this.build();

            AMenuItem result = (AMenuItem)this.menuItem;
            
            this.Reset();

            return result;

        }

    }
```

Since a Builder is meant to be reused, the Concrete Builder comes with a ```Reset``` method. That method is used in the ```GetMenuItem``` method, right after the Product to be returned is created. This ensures that the Builder is ready to be deployed for the creation of a new Product right after it churns one out. 

Our final component is of course the Product being built itself, in this case, a menu item. 

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

We can use the builder in client :

```
HotWingsBuilder chick = new HotWingsBuilder();
chick.GetMenuItem()
```
which is an improvement over:

```
//new Chicken {Id = 1, Name = "Hotwings", Price = 5.99M, ShortDesc = "They're hot!",ChickenType = chickenTypes.First(), ImageThumbUrl="/images/hotwings.jpg"},
```