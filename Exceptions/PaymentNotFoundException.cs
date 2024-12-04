namespace RoadReady.Exceptions
{
    public class PaymentNotFoundException:Exception
    {
        string message;
        public PaymentNotFoundException()
        {
            message = "No Payment is found. An error occurred while searching for Payments .";
        }
        public string Message => message;
    }
}
