using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelecomCustomerPortal_Domain
{
    public class Device
    {
        int Id { get; set; }
        string PhoneNumber { get; set; }
        public List<User> User { get; set; } = new List<User>();
        

    }
}
