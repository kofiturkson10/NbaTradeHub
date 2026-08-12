using NbaTradeHub_Api.Data.Enteties;

namespace NbaTradeHub_Api.Data.Interfaces
{
    public interface IUserRepo
    {
        User? Login(string username, string password);

        User? GetById(int id);

        bool UpdateUser(User user);

        bool UserNameExists(string username);

        bool EmailExists(string email);

        void CreateUser(User user);

        bool DeleteUser(int id);
    }
}
