namespace FullStackDays.Models
{
    public class InsufficientQuantityResult : OrderResult
    {
        public InsufficientQuantityResult(Product alternative)
        {
            Alternative = alternative;
        }

        public Product Alternative { get; }
    }
}
