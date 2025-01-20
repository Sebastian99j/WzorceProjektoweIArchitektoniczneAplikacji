namespace MojBlogCMS.Factory
{
    public interface IPostFactory<T> where T : class
    {
        T Create();
        T Create(Action<T> configure);
    }
}