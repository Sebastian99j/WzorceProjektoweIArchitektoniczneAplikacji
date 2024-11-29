namespace Flyweight
{
    public class GameObject
    {
        private readonly string _name;
        private readonly Texture _texture;

        public GameObject(string name, Texture texture)
        {
            _name = name;
            _texture = texture;
        }

        public void Display()
        {
            Console.WriteLine($"Obiekt: {_name}");
            _texture.Display();
        }
    }
}
