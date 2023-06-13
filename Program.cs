using MavicsBank;
using MavicsBank.Interfaces.Customer_Interface;
using Microsoft.Extensions.DependencyInjection;
using MavicsBank.Implementations.Customer_Implementations;
using MavicsBank.Interfaces.Account_Interface;
using MavicsBank.Implementations.Account_Implementations;


var services = new ServiceCollection();

services.AddScoped<IRegister, Register>();
services.AddScoped<ILogin, Login>();
services.AddScoped<IDashBoard, DashBoard>();
services.AddScoped<ICreateAccount, CreateAccount>();
services.AddScoped<IDeposit, Deposit>();
services.AddScoped<IWithdraw, Withdraw>();
services.AddScoped<ITransfer, Transfer>();
services.AddScoped<ICheckBalance, CheckBalance>();
services.AddScoped<IAccountDetails, AccountDetails>();
services.AddScoped<IAccHelper, Acc_Helper>();
services.AddSingleton<HomePage>();

var serviceProvider = services.BuildServiceProvider();
var home =  serviceProvider.GetRequiredService<HomePage>();

home.MyHomePage();