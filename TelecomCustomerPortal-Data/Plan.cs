using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelecomCustomerPortal_Data
{
    public class Plan
    {
        public int Id { get; set; }
        public string PlanName { get; set; }
        public int PlanPrice { get; set; }
        public int DeviceLimit { get; set; }        

    }
}
