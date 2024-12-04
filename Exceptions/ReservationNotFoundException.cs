namespace RoadReady.Exceptions
{
    public class ReservationNotFoundException:Exception
    {
        string message;
        public ReservationNotFoundException()
        {
            message = "No Reservation found. An error occurred while searching for Reservation .";
        }
        public string Message => message;
    }
}
