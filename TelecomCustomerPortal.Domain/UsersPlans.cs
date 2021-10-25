using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelecomCustomerPortal.Domain
{
    public class UsersPlans
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PlanId { get; set; }
    }
}
