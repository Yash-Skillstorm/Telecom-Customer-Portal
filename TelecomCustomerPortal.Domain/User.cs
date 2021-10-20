using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelecomCustomerPortal.Domain
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Device> Devices { get; set; } = new List<Device>();
    }
}
