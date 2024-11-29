namespace Composite
{
    public class MenuItem : IMenuComponent
    {
        private string _name;
        private decimal _price;

        public MenuItem(string name, decimal price)
        {
            _name = name;
            _price = price;
        }

        public void Display(int indentLevel = 0)
        {
            Console.WriteLine(new string(' ', indentLevel * 2) + $"{_name} - {_price:C}");
        }
    }
}
