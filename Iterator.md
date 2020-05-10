# Iterator 

This design pattern enables the sequential traversal of a elements of a collection without exposing the underlying representation (list, array, stack etc.). An iterator therefore allows us to get items from a collection one by one until all the elements have been returned, all without knowing how the collection actually stores the items it holds.

If you visit the link /Pizza/List, you can see all the Pizza items. There, we simply have several objects of type Pizza created and added to a list of pizzas. Below is the code for that: 

``` 
    pizzas = new List<Pizza>
            {
                new Pizza {Id = 1, Name = "Hawaiian Delight", Price = 5.99M, ShortDesc = "Ham and Pineapple",PizzaType = pizzaTypes.First(), ImageThumbUrl="/images/hawaiian.jpg"},
                new Pizza {Id = 1, Name = "Pepperoni Mashup", Price = 5.99M, ShortDesc = "Cheese", PizzaType = pizzaTypes.ElementAt(1), ImageThumbUrl="/images/pepperoni.jpg" },
                new Pizza {Id = 1, Name = "Veggie Party", Price = 5.99M, ShortDesc = "Vegetables", PizzaType = pizzaTypes.Last(), ImageThumbUrl="/images/veggie.jpg"}

            };
            
```

However, there is also a Pizza collection object, ```PizzaCollection```, that we could be using in place of a generic ```List<T>```. The official decision has been made to switch to using ```PizzaCollection``` and similar custom collections for any future food item objects. 


Bouffe has recently decided to offer chicken as a menu items and we want to be able to have both Pizza and Chicken objects in one big collection which we can iterate through which we shall call ```menuItems```. The problem is that currently ```PizzaCollection``` and ```ChickenCollection``` use different underlying representations. ```PizzaCollection``` uses  ```List<Pizza>``` while ```ChickenCollection``` uses ```ArrayList```. ```menuItems``` therefore has to contain specialized code that will enable it to loop through both ```PizzaCollection``` and ```ChickenCollection```. 

This is where an iterator becomes valuable. Instead of ```menuItems``` containing specialized code that allows it to loop through the collections it contains, what if we handed the duty of looping over to each specific collection to do for itself? That way, our code is extensible because we can now easily just add future possible collections like maybe ```DrinkCollection``` or ```DessertCollection``` without having to teach ```menuItems``` how to traverse them. In fact, ```menuItems```, ```PizzaCollection``` and ```ChickenCollection``` will all use the same underlying Iterator interface, ```IGenericIterator```. 

Our first step is to build an interface for collections called ```IOrderItemCollection```:

```
public interface IOrderItemCollection
    {
        IGenericIterator CreateIterator();
    }
```

Then we implement that for both ```PizzaCollection``` :

```
public class PizzaCollection : IOrderItemCollection
    {
        private List<Pizza> items = new List<Pizza>(); //notice that PizzaCollection stores its pizza objects in a List

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
        public Pizza this[int index]
        {
            get => items[index];
            set => items.Add(value);
            
        }
    }
```

and ```ChickenCollection```:

```
public class ChickenCollection : IOrderItemCollection
    {
        private ArrayList items = new ArrayList(); //On the other hand, ChickenCollection uses an ArrayList

        public IGenericIterator CreateIterator()
        {
            return new ChickenIterator(this);
        }

        //Get number of pizzas in collection
        public int Count
        {
            get => items.Count;
        }

        //Class Indexer
        public Chicken this[int index]
        {
            get => (Chicken)items[index];
            set => items.Add(value);

        }
    }
```

Our next step is to build an interface for iterators called ```IGenericIterator```:

```
  public interface IGenericIterator
    {
        object First();

        object Next();

        bool IsDone { get;  }

        object Current { get; }
    }

```

We then implent this in ```PizzaIterator```

```
 public class PizzaIterator : IGenericIterator
    {
        private PizzaCollection pizzas;
        private int current = 0;
        private int step = 1;

        public PizzaIterator(PizzaCollection pizzas)
        {
            this.pizzas = pizzas;
        }

        //Tell if iteration has completed
        public bool IsDone 
        {
            get => current >= pizzas.Count; 
        }

        //Get pizza at current iterator position
        public object Current => pizzas[current] as Pizza;

        //Get first Pizza
        public object First()
        {
            current = 0;
            return pizzas[current] as Pizza;
        }

        //Get next Pizza
        public object Next()
        {
            current += step;
            if (!IsDone)
            {
                return pizzas[current] as Pizza;
            }
            else
            {
                return null;
            }
        }
    }
```

and in ```ChickenIterator```

```
public class ChickenIterator : IGenericIterator
    {
        private ChickenCollection chickens;
        private int current = 0;
        private int step = 1;

        public ChickenIterator(ChickenCollection chickens)
        {
            this.chickens = chickens;
        }

        //Tell if iteration has completed
        public bool IsDone
        {
            get => current >= chickens.Count;
        }

        //Get chicken at current iterator position
        public object Current => chickens[current] as Chicken;

        //Get first Chicken
        public object First()
        {
            current = 0;
            return chickens[current] as Chicken;
        }

        //Get next Chicken
        public object Next()
        {
            current += step;
            if (!IsDone)
            {
                return chickens[current] as Chicken;
            }
            else
            {
                return null;
            }
        }
    }
```

Now that all these are setup, we can use our newly granted iterating powers to display both Pizza and Chicken items on Home/Index. 

First in the Home Controller :

```
            IGenericIterator pizzaIterator = pizzaz.CreateIterator();
            IGenericIterator chickenIterator = chickenz.CreateIterator();
                        
            List<IGenericIterator> menuItems = new List<IGenericIterator>();
                        
            menuItems.Add(pizzaIterator);
            menuItems.Add(chickenIterator);
            
            MenuViewModel allItems = new MenuViewModel(menuItems);
            return View(allItems);
```

And then in the Home View:

```
@foreach (var iterator in Model.menuItems)
    {
        for (var item = iterator.First(); !iterator.IsDone; item = iterator.Next())
        {
            <div class="card mt-4">
                <img class="card-img-top" src="@(((MenuItem)item).ImageThumbUrl)" alt="Image of a pizza" />
                <div class="card-body">
                    <div class="card-text text-center">
                        <h3>@(((MenuItem)item).Price.ToString("c"))</h3>
                        <h3>
                            <a>@(((MenuItem)item).Name)</a>
                        </h3>
                        <p>@(((MenuItem)item).ShortDesc)</p>
                    </div>
                </div>
            </div>
        }
    }

```