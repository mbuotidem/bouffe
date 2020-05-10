# Abstract Factory

This design pattern lets you create families of related objects without specifying their concrete classes. It is used when you want to make sure your clients create products that belong together.


Due to overwhelming customer requests, Bouffe has decided to create Combos. A combo here is a pairing of a type of pizza with a type of chicken. We can consider this combo pairing as a family of related objects. As such, it is a prime candidate for creation using the Abstract Factory pattern. 


First we have the Abstract Factory interface that declares a set of methods that return different abstract products. Pizza and wings represent a conceptual family of objects for our purposes. 

```
  public interface IComboFactory
    {
        IMenuItem CreatePizza();

        IMenuItem CreateWings();
    }
```

Next are our concrete factories. For our trial run, we selected the two most popularly requested combo's, Hawaiian Pizza with Hot wings and Veggie Pizza with Plain Wings. 

Note that we use our existing factory method to implement our concrete factories. Code re-use ftw!

```
    public class HawaiianHotFactory : IComboFactory
    {
        public IMenuItem CreatePizza()
        {
            return new PizzaFactory().CreateMenuItem("Hawaiian Delight", "Hawaiian");
        }

        public IMenuItem CreateWings()
        {
            return new ChickenFactory().CreateMenuItem("HotWings");
        }


    }
```

```
    public class VeggiePlainFactory : IComboFactory
    {
        public IMenuItem CreatePizza()
        {
            return new PizzaFactory().CreateMenuItem("Veggie Party", "Veggie");
        }

        public IMenuItem CreateWings()
        {
            return new ChickenFactory().CreateMenuItem("PlainWings");
        }
    }
```

For the Abstract Factory pattern to work, the distinct products should have a base interface. Below is the ```AMenuItem``` abstract class from which the products inherit. Note that ```AMenuItem``` implements the ```IMenuItem``` interface. 

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

And here we have the ```Pizza``` and ```Chicken``` classes which implement it. The code snippets for the ```Pizza``` and ```Chicken``` classes only show the properties specific to them since the others are inherited from the abstract class ```AMenuItem``` above.

```
    public class Pizza : AMenuItem
    {
        //This constructor is for the builder pattern
        public Pizza(PizzaType pizzaType)
        {
            PizzaType = pizzaType;
        }

        //This constructor is for object creation via the 'new' operator
        public Pizza()
        {

        }
        
        //EF Core Entities and navigational property
        public int PizzaTypeId { get; set; }
        public PizzaType PizzaType { get; set; }
    }
```

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

Finally, the client uses the abstract factory through the abstract types:



```
            //First we create an iterator to store the combo iterator
            List<IGenericIterator> combos = new List<IGenericIterator>();

            //Then we create 2 collections where we will store the products created using the factory.
            //HH refers to the Hawaiian with Hotwings combo and VG refers to the Veggie and Plainwings combo. 

            ComboCollection HHCombo = new ComboCollection();
            ComboCollection VPCombo = new ComboCollection();

            //We create the factory for combo HawaiianHot and then ask the factory to make the required products.
            var HHFactory = new HawaiianHotFactory();
            HHCombo[1] = HHFactory.CreatePizza();
            HHCombo[2] = HHFactory.CreateWings();

            //We create the factory for combo VeggiePlain and then ask the factory to make the required products.
            var VGFactory = new VeggiePlainFactory();
            VPCombo[1] = VGFactory.CreatePizza();
            VPCombo[2] = VGFactory.CreateWings();

            //Finally, we add the iterators for these products into our 
            combos.Add(HHCombo.CreateIterator());
            combos.Add(VPCombo.CreateIterator());
```

With the iterator fully hydrated, we can pass it over to the ViewModel to be displayed by the View. 