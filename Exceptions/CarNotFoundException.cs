namespace RoadReady.Exceptions
{
    public class CarNotFoundException:Exception
    {
        string message;
        public CarNotFoundException()
        {
            message = "No car found. An error occurred while searching for cars.";
        }
        public string Message => message;
    }
}
