namespace RoadReady.Exceptions
{
    public class UserNotFoundException:Exception
    {
        string message;
        public UserNotFoundException()
        {
            message = "No User found. An error occurred while searching for User.";
        }
        public string Message => message;
    }
}
