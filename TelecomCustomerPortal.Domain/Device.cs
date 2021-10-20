using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelecomCustomerPortal.Domain
{
    public class Device
    {
        int Id { get; set; }
        string Name { get; set; }
        string PhoneNumber { get; set; }

        int UserId { get; set; }
    }
}
