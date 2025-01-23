using MojBlogCMS.Models;

namespace MojBlogCMS.Factory
{
    public interface IPostFactory<T> where T : IPost
    {
        T Create(ComponentType type = ComponentType.POST);
        T Create(Action<T> configure, ComponentType type = ComponentType.POST);
    }
}