﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelecomCustomerPortal.Domain.DAO
{
    interface IUserDAO
    {
        public List<User> LogIn(string email, string password);


    }
}