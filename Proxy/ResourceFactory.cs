namespace Proxy
{
    public static class ResourceFactory
    {
        public static IResource CreateResource(string type, string password = null)
        {
            return type switch
            {
                "public" => new PublicResource(),
                "protected" => new AccessProxy(new ProtectedResource(), password),
                _ => throw new ArgumentException("Invalid resource type.")
            };
        }
    }
}
