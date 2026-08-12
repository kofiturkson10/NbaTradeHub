using NbaTradeHub_Api.Data.Enteties;

namespace NbaTradeHub_Api.Core.Interfaces
{
    public interface IUserService
    {
        string? Login(string username, string password);
        bool Register (string username, string email, string password);
        bool UpdateUser(int userId, string username, string email, string password);
        bool DeleteUser(int id);

    }
}
