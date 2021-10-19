using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelecomCustomerPortal_Domain
{
    public class Plan
    {
        public int Id { get; set; }
        public string PlanName { get; set; }
        public int Price { get; set; }
        public int DeviceLimit { get; set; }

        public List<User> Users { get; set; } = new List<User>();

    }
}
