using CarDealerApi.Data;
using CarDealerApi.Interface;
using CarDealerApi.Models;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;

namespace CarDealerApi.Repository
{
    public class UserRepository:UserInterface
    {
        private readonly AppDBContext _context;
        public UserRepository(AppDBContext context)=> _context = context;
        public bool CreateUser(User user)
        {
            _context.Add(user); 
            return Save();
        }

        public bool DeleteUser(User user)
        {
            _context.Remove(user);
            return Save();
        }

        public User GetUserByName(string user)
        {
            return _context.users.Where(u=>u.Username== user).FirstOrDefault()?? null;
        }
        public User GetUserById(int id)
        {
            return _context.users.Where(u => u.Id == id).FirstOrDefault() ?? null;
        }

        public ICollection<User> GetUsers()
        {
            return _context.users.OrderBy(u=>u.Id).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateUser(User user)
        {
            _context.Update(user);
            return Save();
        }

        public bool UserExitsByUser(string username)
        {
            return _context.users.Any(u=>u.Username == username);
        }

        public bool UserExitsById(int id)
        {
            return _context.users.Any(u => u.Id == id);
        }

        public bool ValidateUserPassword(User user, string password)
        {
            byte[] salt = user.salt;
            byte[] encryptedPassword = EncryptPassword(password, salt);

            string savedPassword = Convert.ToBase64String(user.Password);
            string enteredPassword = Convert.ToBase64String(encryptedPassword);

            return savedPassword == enteredPassword;
        }

        private byte[] EncryptPassword(string password, byte[] salt)
        {
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000))
            {
                byte[] hash = pbkdf2.GetBytes(32);
                return hash;
            }
        }

        public ICollection<Car> GetCarByUser(int userId)
        {
            return _context.cars.Where(c=>c.User.Id==userId).OrderBy(c=>c.Id).ToList();
        }
    }
}
