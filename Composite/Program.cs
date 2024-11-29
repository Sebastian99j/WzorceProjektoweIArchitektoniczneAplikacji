namespace Composite
{
    class Program
    {
        static void Main(string[] args)
        {
            var mainMenu = new MenuCategory("Menu Główne");

            var drinks = new MenuCategory("Napoje");
            drinks.Add(new MenuItem("Woda", 5.00m));
            drinks.Add(new MenuItem("Kawa", 10.00m));
            drinks.Add(new MenuItem("Herbata", 8.00m));

            var food = new MenuCategory("Dania Główne");
            var pasta = new MenuCategory("Makarony");
            pasta.Add(new MenuItem("Spaghetti Bolognese", 25.00m));
            pasta.Add(new MenuItem("Carbonara", 28.00m));

            var pizza = new MenuCategory("Pizze");
            pizza.Add(new MenuItem("Margherita", 22.00m));
            pizza.Add(new MenuItem("Pepperoni", 26.00m));

            food.Add(pasta);
            food.Add(pizza);

            var desserts = new MenuCategory("Desery");
            desserts.Add(new MenuItem("Lody", 15.00m));
            desserts.Add(new MenuItem("Sernik", 18.00m));

            mainMenu.Add(drinks);
            mainMenu.Add(food);
            mainMenu.Add(desserts);

            mainMenu.Display();
        }
    }
}
