namespace MojBlogCMS.Strategy
{
    public class ValidationManager<T>
    {
        private readonly IEnumerable<IValidationStrategy<T>> _strategies;

        public ValidationManager(IEnumerable<IValidationStrategy<T>> strategies)
        {
            _strategies = strategies;
        }

        public bool Validate(string strategyName, T entity, out string errorMessage)
        {
            var strategy = _strategies.FirstOrDefault(s => s.Name.Equals(strategyName, StringComparison.OrdinalIgnoreCase));
            if (strategy == null)
            {
                errorMessage = $"No validation strategy found for name: {strategyName}.";
                return false;
            }

            return strategy.Validate(entity, out errorMessage);
        }
    }
}