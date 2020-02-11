namespace FullStackDays.Models
{
    public class InvalidOrderResult : OrderResult
    {
        public InvalidOrderResult(string message)
        {
            Message = message;
        }

        public string Message { get; }
    }
}
