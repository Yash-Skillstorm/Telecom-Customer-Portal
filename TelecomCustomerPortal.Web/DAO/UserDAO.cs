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
       
   

        
        public void LogIn(string email, string password)
        {
            List<User> user;

            //user = User.Where(p => p.Email == email).ToList();

            //_context.User.Where(p => p.Name == name).ToList();
           
            
        }
      
    }
}
