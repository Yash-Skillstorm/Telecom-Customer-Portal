using System;
using System.Collections.Generic;

namespace TelecomCustomerPortal_Domain
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set;  }
        public List<Device> Device { get; set; } = new List<Device>();

    }
}
