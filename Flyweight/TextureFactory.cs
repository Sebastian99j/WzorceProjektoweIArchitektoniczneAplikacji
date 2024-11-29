namespace Flyweight
{
    public class TextureFactory
    {
        private readonly Dictionary<string, Texture> _textures = new Dictionary<string, Texture>();

        public Texture GetTexture(string fileName)
        {
            if (!_textures.ContainsKey(fileName))
            {
                _textures[fileName] = new Texture(fileName);
            }
            return _textures[fileName];
        }
    }
}
