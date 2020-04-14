
# Markdown File

MVC stands for Model View Controller. Its objective is to improve the separation of concerns through the 
use of loosely coupled architecture. 

Models: These are classes that contain the data the application uses. 

Controller: These provide the logic that work on the model and transfer data to the views. 

View: Views display the data they receive from the Controller. 

Let us use the Pizza class to demonstrate MVC. 

First we have our model. This class contains properties that define our representation of a pizza available for sale.

```
public class Pizza
    {
        public int PizzaId { get; set; }
        public string Name { get; set; }
        public string ShortDesc { get; set; }
        public string LongDesc { get; set; }
        public decimal Price { get; set; }

    }
```

Next we have our controller. In this controller, we instantiate some pizza objects based on the Pizza model above. Then we pass list of 
pizza models over to the view in the method ```ViewResult List()```.

```
public class PizzaController : Controller
    {
        IEnumerable<Pizza> pizzas = Enumerable.Empty<Pizza>();
        
        public PizzaController(IEnumerable<Pizza> pizzas)
        {
            this.pizzas = pizzas;
        }
        public IActionResult Index()
        {
            return View();
        }

        public ViewResult List()
        {
            return View(pizzas);
        }
    }
```

Finally, our View takes the passed collection of pizzas and displays it using an HTML template that we provide. 

```
@model IEnumerable<bouffe.Models.Pizza>
 
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>bouffe</title>

</head>
<body>
    @foreach (var pizza in Model)
    {
        <div>
            <h2>@pizza.Name</h2>
            <h3>@pizza.Price.ToString("c")</h3>
            <h3>@pizza.ShortDesc</h3>
        </div>
    }
</body>
</html>

```

