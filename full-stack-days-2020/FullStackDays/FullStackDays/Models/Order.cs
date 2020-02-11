using NodaTime;

namespace FullStackDays.Models
{
    public class Order
    {
        public Order(Product product, int quantity, Instant orderedOn)
        {
            Product = product;
            Quantity = quantity;
            OrderedOn = orderedOn;
        }

        public Product Product { get; }

        public int Quantity { get; }

        public Instant OrderedOn { get; }
    }
}
