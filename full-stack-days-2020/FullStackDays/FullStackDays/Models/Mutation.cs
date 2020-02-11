using NodaTime;
using System.Linq;

namespace FullStackDays.Models
{
    public class Mutation
    {
        public Review CreateReview(ReviewInput input)
        {
            var product = MockData.Products.SingleOrDefault(p => p.Id == input.ProductId);

            return new Review(1001, input.ProductId, "Nigel Sampson", input.Text ?? "");
        }

        public OrderResult CreateOrder(OrderInput input)
        {
            var product = MockData.Products.SingleOrDefault(p => p.Id == input.ProductId);

            if (product == null)
                return new InvalidOrderResult("Invalid product");

            if (input.Quantity < 1)
                return new InvalidOrderResult("Invalid quantity");

            if (input.Quantity > 10)
                return new InsufficientQuantityResult(MockData.Products.Last());

            return new OrderCompletedResult(new Order(product, input.Quantity, SystemClock.Instance.GetCurrentInstant()));
        }
    }
}
