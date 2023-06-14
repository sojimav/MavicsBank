using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MavicsBank.Interfaces.Customer_Interface;
using MavicsBank.Validations;


namespace MavicsBank
{
    internal class HomePage 
    {
        private readonly IRegister _reg;
        private readonly ILogin _login;
        public HomePage(IRegister reg, ILogin login)
        {
            _reg = reg;
            _login = login;
        }

        public void MyHomePage()
        {

            string collectInput;
            do
            {
                Console.Clear();
                Console.WriteLine("\nWelcome to Mavics Bank\n");
                Console.Write(">>Press 1 to Register\n>>Press 2 to Login\n>> or Q to Exit: ");
                collectInput = Console.ReadLine()!;
                if (HomePageValidation.InitialPromptValidation(collectInput.ToUpper()))
                {
                    if(collectInput == "1")
                    {
                       _reg.RegisterCustomer();
                        MyHomePage();
                    }
                    else if(collectInput == "2")
                    {
                        _login.LogMeIn();
                    }
                                       
                }

            }
            while (!HomePageValidation.InitialPromptValidation(collectInput.ToUpper()));


        }
    }
}
