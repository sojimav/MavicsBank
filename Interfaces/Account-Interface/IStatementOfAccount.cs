﻿using MavicsBank.Models.Customer_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MavicsBank.Interfaces.Account_Interface
{
    internal interface IStatementOfAccount
    {
        void MyStatementOfAccount(Customer loggedInCustomer);
    }
}
