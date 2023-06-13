﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MavicsBank.Validations;
using MavicsBank.Models.Customer_Model;
using MavicsBank.Interfaces.Customer_Interface;
using MavicsBank.Interfaces.Account_Interface;

namespace MavicsBank.Implementations.Customer_Implementations
{
    internal class DashBoard : IDashBoard
    {
        private readonly ICreateAccount _createAccount;
        private readonly IDeposit _deposit;
        private readonly IWithdraw _withdraw;
        private readonly ITransfer _transfer;
        public DashBoard(ICreateAccount createAccount, IDeposit deposit, IWithdraw withdraw, ITransfer transfer)
        {
            _createAccount = createAccount;
            _deposit = deposit;
            _withdraw = withdraw;
            _transfer = transfer;
        }
        public void MyDashBoard(Customer loggedInCustomer)
        {
            Console.WriteLine($"Welcome {loggedInCustomer.FullName}!");
            Console.Write(">>1: Create Account\n>>2: Deposit\n>>3: Withdrawal\n>>4: Transfer\n>>5: Check Balance\n>>6: " +
                   "Display Account Details\n>>7: Get Account Statement\n>>8: Log Out\n>>Q: To Quit\n\nEnter Your Choice: ");
            string choice = Console.ReadLine()!.ToUpper();

            if (DashBoardValidation.DashBoardValid(choice.ToUpper()))
            {

                if(choice == "1")
                { 
                    _createAccount.CreateNewAccount(loggedInCustomer);
                    MyDashBoard(loggedInCustomer);

                }
                else if(choice == "2")
                {
                    _deposit.DepositMoney(loggedInCustomer);
                    MyDashBoard(loggedInCustomer);
                }
                else if(choice == "3")
                {
                    _withdraw.WithdrawMoney(loggedInCustomer);
                    MyDashBoard(loggedInCustomer);
                }
                else if(choice == "4")
                {
                    _transfer.TransferMoney(loggedInCustomer);
                    MyDashBoard(loggedInCustomer);
                }
               



            }
           


        }
    }
}