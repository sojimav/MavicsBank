using MavicsBank.Models.Customer_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MavicsBank.Interfaces.Customer_Interface
{
    internal interface IHelper
    {
        string FullName();
        string Email();
        string Password();
        int CustomerId();
        List<Customer> ReadFromFile(string filepath);
    }
}
