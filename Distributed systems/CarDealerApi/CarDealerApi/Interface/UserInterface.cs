using CarDealerApi.Models;

namespace CarDealerApi.Interface
{
    public interface UserInterface
    {
        ICollection<User> GetUsers();
        User GetUserById(int Id);
        User GetUserByName(string username);
        bool UserExitsByUser(string username);
        bool UserExitsById(int id);
        bool CreateUser(User user);
        bool Save();
        bool UpdateUser(User user);
        bool DeleteUser(User user);
        bool ValidateUserPassword(User user, string password);
        ICollection<Car> GetCarByUser(int userId);
    }
}
