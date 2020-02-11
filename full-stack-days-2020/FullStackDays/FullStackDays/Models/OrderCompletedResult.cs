namespace FullStackDays.Models
{
    public class OrderCompletedResult : OrderResult
    {
        public OrderCompletedResult(Order order)
        {
            Order = order;
        }

        public Order Order { get; }
    }
}
