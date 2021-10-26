using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelecomCustomerPortal.Domain
{
    public class Summary
    {
        public int? Id { get; set; }
        public int UserId { get; set; }
        public int DeviceId { get; set; }
        public string DeviceName { get; set; }
        public int PlanId { get; set; }
        public string PlanName { get; set; }
        public int Price { get; set; }
        public int DeviceLimit { get; set; }        

    }
}
