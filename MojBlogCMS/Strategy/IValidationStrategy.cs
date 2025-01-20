namespace MojBlogCMS.Strategy
{
    public interface IValidationStrategy<T>
    {
        string Name { get; }
        bool Validate(T entity, out string errorMessage);
    }
}