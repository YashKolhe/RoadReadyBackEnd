using System.Collections.Generic;
using RoadReady.Data;
using RoadReady.Models;

namespace RoadReady.Repositories
{
    public class PaymentService : IPaymentService
    {
        private readonly ApplicationDbContext _context;

        public PaymentService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Payment> GetAllPayments()
        {
            try
            {
                return _context.Payments.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Payment GetPaymentById(int id)
        {
            try
            {
                return _context.Payments.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Payment GetPaymentByUserName(string userName)
        {
            try
            {
                return _context.Payments.Find(userName);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public int AddPayment(Payment payment)
        {
            try
            {
                _context.Payments.Add(payment);
                _context.SaveChanges();
                return payment.PaymentId;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string UpdatePayment(Payment payment)
        {
            try
            {
                var existingPayment = _context.Payments.Find(payment.PaymentId);
                if (existingPayment == null) return "Payment not found";

                existingPayment.ReservationId = payment.ReservationId;
                existingPayment.PaymentDate = payment.PaymentDate;
                existingPayment.Amount = payment.Amount;
                existingPayment.PaymentMethod = payment.PaymentMethod;
                existingPayment.Status = payment.Status;

                _context.SaveChanges();
                return "Payment updated successfully";
            }
            catch(Exception)
            {
                throw;
            }
        }

        public string DeletePayment(int id)
        {
            try
            {
                var existingPayment = _context.Payments.Find(id);
                if (existingPayment == null) return "Payment not found";

                _context.Payments.Remove(existingPayment);
                _context.SaveChanges();
                return "Payment deleted successfully";
            }
            catch (Exception) 
            {
                throw;
            }
        }
    }
}
