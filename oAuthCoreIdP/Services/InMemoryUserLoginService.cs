using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace oAuthCoreIdP.Services
{
    public class InMemoryUser
    {
        public string Subject { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public List<Claim>  Claims { get; set; }
    }
    public interface IInMemoryUserLoginService
    {
        bool ValidateCredentials(string userName, string password);

        InMemoryUser FindByUsername(string userName);

        InMemoryUser FindByExternalProvider(string provider, string userId);

        InMemoryUser AutoProvisionUser(string provider, string userId, List<Claim> claims);
    }
    public class InMemoryUserLoginService : IInMemoryUserLoginService
    {
        public bool ValidateCredentials(string userName, string password)
        {
            var users = Users.Get();
            var u = users.FirstOrDefault(c => c.Username == userName && c.Password == password);
            return u != null;
        }

        public InMemoryUser FindByUsername(string userName)
        {
            var users = Users.Get();
            var u = users.FirstOrDefault(c => c.Username == userName);
            return u;
        }

        public InMemoryUser FindByExternalProvider(string provider, string userId)
        {
            var users = Users.Get();
            var u = users.FirstOrDefault(c => c.Username == userId);
            return u;
        }

        public InMemoryUser AutoProvisionUser(string provider, string userId, List<Claim> claims)
        {
            var users = Users.Get();
            var u = users.FirstOrDefault(c => c.Username == userId);
            return u;
        }
    }
}
