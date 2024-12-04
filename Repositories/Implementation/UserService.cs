using RoadReady.Data;
using RoadReady.Models;

namespace RoadReady.Repositories
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<User> GetAllUsers()
        {
            try
            {
                return _context.Users.ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public User GetUserById(int id)
        {
            try
            {
                return _context.Users.Find(id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public User GetUserByUserName(string userName)
        {
            try
            {
                return _context.Users.FirstOrDefault(u => u.FirstName == userName);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int AddUser(User user)
        {
            try
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                return user.UserId;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public string UpdateUser(User user)
        {
            try
            {
                var existingUser = _context.Users.Find(user.UserId);
                if (existingUser == null) return "User not found";

                existingUser.FirstName = user.FirstName;
                existingUser.LastName = user.LastName;
                existingUser.Email = user.Email;
                existingUser.PhoneNumber = user.PhoneNumber;
                existingUser.Role = user.Role;

                _context.SaveChanges();
                return "User updated successfully";
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public string DeleteUser(int id)
        {
            try
            {
                var existingUser = _context.Users.Find(id);
                if (existingUser == null) return "User not found";

                _context.Users.Remove(existingUser);
                _context.SaveChanges();
                return "User deleted successfully";
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
