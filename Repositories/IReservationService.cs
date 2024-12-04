using RoadReady.Models;

namespace RoadReady.Repositories
{
    public interface IReservationService
    {
        List<Reservation> GetAllReservations();
        Reservation GetReservationById(int id);
        Reservation GetReservationByUserId(int userId);

        int AddReservation(Reservation reservation);
        string UpdateReservation(Reservation reservation);
        string DeleteReservation(int id);
    }
}
