using System.Collections.Generic;
using RoadReady.Data;
using RoadReady.Models;

namespace RoadReady.Repositories
{
    public class ReservationService : IReservationService
    {
        private readonly ApplicationDbContext _context;

        public ReservationService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Reservation> GetAllReservations()
        {
            try
            {
                return _context.Reservations.ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Reservation GetReservationById(int id)
        {
            try
            {
                return _context.Reservations.Find(id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public Reservation GetReservationByUserId(int userId)
        {
            try
            {
                return _context.Reservations.Find(userId);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public int AddReservation(Reservation reservation)
        {
            try
            {
                _context.Reservations.Add(reservation);
                _context.SaveChanges();
                return reservation.ReservationId;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public string UpdateReservation(Reservation reservation)
        {
            try
            {
                var existingReservation = _context.Reservations.Find(reservation.ReservationId);
                if (existingReservation == null) return "Reservation not found";

                existingReservation.UserId = reservation.UserId;
                existingReservation.CarId = reservation.CarId;
                existingReservation.PickupDate = reservation.PickupDate;
                existingReservation.DropoffDate = reservation.DropoffDate;
                existingReservation.TotalAmount = reservation.TotalAmount;
                existingReservation.Status = reservation.Status;

                _context.SaveChanges();
                return "Reservation updated successfully";
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public string DeleteReservation(int id)
        {
            try
            {
                var existingReservation = _context.Reservations.Find(id);
                if (existingReservation == null) return "Reservation not found";

                _context.Reservations.Remove(existingReservation);
                _context.SaveChanges();
                return "Reservation deleted successfully";
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
