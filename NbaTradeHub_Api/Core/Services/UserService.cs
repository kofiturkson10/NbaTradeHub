using Microsoft.IdentityModel.Tokens;
using NbaTradeHub_Api.Core.Interfaces;
using NbaTradeHub_Api.Data.Enteties;
using NbaTradeHub_Api.Data.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NbaTradeHub_Api.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _repo;
        private readonly IConfiguration _config;

        public UserService(IUserRepo repo, IConfiguration config)
        {
            _repo = repo;
            _config = config;
        }


        public string? Login(string username, string password)
        {
            var user = _repo.Login(username, password);
            if (user == null)
                return null;

            var issuer = _config["Jwt:Issuer"];
            var audience = _config["Jwt:Audience"];
            var key = _config["Jwt:Key"];

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(ClaimTypes.Name, user.UserName)
            };

            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var creds = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(60),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);

        }


        public bool Register(string username, string email, string password)
        {
            if (_repo.UserNameExists(username))
                return false;

            if (_repo.EmailExists(email))
                return false;

            var user = new User
            {
                UserName = username,
                Email = email,
                Password = password
            };

            _repo.CreateUser(user);

            return true;
        }


        public bool UpdateUser(int userId, string username, string email, string password)
        {
            var user = _repo.GetById(userId);
            if (user == null)
                return false;

            user.UserName = username;
            user.Email = email;
            user.Password = password;

            return _repo.UpdateUser(user);
        }


        public bool DeleteUser(int id)
        {
            return _repo.DeleteUser(id);
        }
    }
}
