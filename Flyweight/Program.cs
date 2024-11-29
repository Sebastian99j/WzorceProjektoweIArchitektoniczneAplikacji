namespace Flyweight
{
    class Program
    {
        static void Main(string[] args)
        {
            var textureFactory = new TextureFactory();

            var treeTexture = textureFactory.GetTexture("tree.png");
            var rockTexture = textureFactory.GetTexture("rock.png");
            var characterTexture = textureFactory.GetTexture("character.png");

            var tree1 = new GameObject("Drzewo 1", treeTexture);
            var tree2 = new GameObject("Drzewo 2", treeTexture);
            var rock = new GameObject("Skała", rockTexture);
            var character = new GameObject("Postać", characterTexture);

            tree1.Display();
            tree2.Display();
            rock.Display();
            character.Display();
        }
    }
}
