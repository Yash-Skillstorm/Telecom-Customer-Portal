
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelecomCustomerPortal.Domain;

namespace TelecomCustomerPortal.Data
{
    public class TelecomCustomerPortalContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Device> Device { get; set; }
        public DbSet<Plan> Plan { get; set; }
        public DbSet<UsersPlans> UsersPlans { get; set; }
        public DbSet<Summary> Summary { get; set; }
        public DbSet<UserPlanDevice> UserPlanDevice { get; set; }
        public TelecomCustomerPortalContext()
        {

        }
        public TelecomCustomerPortalContext(DbContextOptions options) : base(options)
        {

        }
    }
}