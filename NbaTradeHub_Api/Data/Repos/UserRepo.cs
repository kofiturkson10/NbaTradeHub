using NbaTradeHub_Api.Data.Interfaces;
using NbaTradeHub_Api.Data.Enteties;

namespace NbaTradeHub_Api.Data.Repos
{
    public class UserRepo : IUserRepo
    {
        private readonly NbaTradesContext _context;

        public UserRepo(NbaTradesContext context)
        {
            _context = context;
        }


        public User? Login(string username, string password)
        {
            return _context.Users
                   .SingleOrDefault(u => u.UserName == username && u.Password == password);
        }


        public bool UserNameExists(string username)
        {
            return _context.Users.Any(u => u.UserName == username);
        }


        public bool EmailExists(string email)
        {
            return _context.Users.Any(u => u.Email == email);
        }


        public void CreateUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }


        public User? GetById(int id)
        {
            return _context.Users.FirstOrDefault(u => u.UserId == id);
        }


        public bool UpdateUser(User user)
        {
            var userOrg = _context.Users
                          .SingleOrDefault(u => u.UserId == user.UserId);

            if (userOrg == null)
            {
                return false;
            }

            _context.Entry(userOrg)
                    .CurrentValues
                    .SetValues(user);

            _context.SaveChanges();

            return true;
        }


        public bool DeleteUser(int id)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserId == id);

            if (user == null)
            return false;

            _context.Users.Remove(user);
            _context.SaveChanges();

            return true;
        }
    }
}
