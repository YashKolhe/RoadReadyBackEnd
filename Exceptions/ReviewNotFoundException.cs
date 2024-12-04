namespace RoadReady.Exceptions
{
    public class ReviewNotFoundException:Exception
    {
        string message;
        public ReviewNotFoundException()
        {
            message = "No Review deatils  found. An error occurred while searching for car deatils.";
        }
        public string Message => message;
    }
}
