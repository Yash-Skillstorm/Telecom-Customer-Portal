using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelecomCustomerPortal.Data;

namespace TelecomCustomerPortal.Domain.DAO
{
    public class UserDAO : IUserDAO
    {
       
        private readonly TelecomCustomerPortalContext _context;

        
        public List<User> LogIn(string email, string password)
        {
            List<User> user;

            user = _context.User.Where(p => p.Email == email).ToList();

            //_context.User.Where(p => p.Name == name).ToList();
           
            return user;
        }
      
    }
}
