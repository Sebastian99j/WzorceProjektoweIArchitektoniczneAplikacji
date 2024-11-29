namespace Composite
{
    public class MenuCategory : IMenuComponent
    {
        private string _name;
        private List<IMenuComponent> _components;

        public MenuCategory(string name)
        {
            _name = name;
            _components = new List<IMenuComponent>();
        }

        public void Add(IMenuComponent component)
        {
            _components.Add(component);
        }

        public void Remove(IMenuComponent component)
        {
            _components.Remove(component);
        }

        public void Display(int indentLevel = 0)
        {
            Console.WriteLine(new string(' ', indentLevel * 2) + _name);
            foreach (var component in _components)
            {
                component.Display(indentLevel + 1);
            }
        }
    }
}
