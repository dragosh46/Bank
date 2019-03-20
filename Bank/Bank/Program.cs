using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class Program
    {
        static void Main(string[] args)
        {
            char action='a';

            Console.WriteLine("Enter the bank name:");
            string bankName = Console.ReadLine();


            Menu menu = new Menu();
            menu.PrincipalMenu(ref action);

            Console.WriteLine("Choose an action:");
            action = Convert.ToChar(Console.ReadLine().ToLower());
            while (action != 'h')
            {
                switch (action)
                {
                    case 'm':
                        Menu menuReturn = new Menu();
                        menuReturn.PrincipalMenu(ref action);

                        Console.WriteLine("Choose an action:");
                        action = Convert.ToChar(Console.ReadLine().ToLower());
                        break;
                    case 'a':
                        Console.Clear();
                        AccountList CreateNewAccount = new AccountList();
                        
                            Console.WriteLine("Enter the name: ");
                            string Name = Console.ReadLine();
                            Console.WriteLine("Enter the adress: ");
                            string Adress = Console.ReadLine();
                            Console.WriteLine("Enter the amount");
                            double Amount = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine("Enter the IBAN: ");
                            string iBAN = Console.ReadLine();
                            CreateNewAccount.AddAccount(Name, Amount, iBAN, Adress);

                        action = 'm';
                        break;
                    case 'b':
                        Console.Clear();
                        Console.WriteLine("Enter the IBAN: ");
                        string depositIBAN = Console.ReadLine();
                        AccountList accountForDeposit = new AccountList();
                        double initialAmount = accountForDeposit.GetInitialAmount(depositIBAN);
                        accountForDeposit.Deposit(depositIBAN, initialAmount);
                        action = 'm';
                        break;
                    case 'c':
                        Console.Clear();
                        Withdraw withdraw = new Withdraw();
                        Console.WriteLine("Enter the IBAN: ");
                        string withdrawIBAN = Console.ReadLine();
                        AccountList accountForWithdraw = new AccountList();
                        double initialWithdrawAmount = accountForWithdraw.GetInitialAmount(withdrawIBAN);
                        withdraw.GetWithdraw(withdrawIBAN, ref initialWithdrawAmount);

                        break;
                    case 'd':
                        Console.Clear();
                        Console.WriteLine("Enter the IBAN: ");
                        string soldIBAN = Console.ReadLine();
                        AccountList accountForSold = new AccountList();
                        double soldAmount = accountForSold.GetInitialAmount(soldIBAN);

                        Sold sold = new Sold();
                        sold.GetSold(soldIBAN, soldAmount);

                        break;

                    case 'e':
                        Console.Clear();
                        AccountList deleteAccount = new AccountList();
                        Console.WriteLine("Enter the name for deleting the account:");
                        string nameForDelete = Console.ReadLine();
                        Console.WriteLine("Enter the IBAN for deleting the account:");
                        string ibanForDelete = Console.ReadLine();
                        var newList = deleteAccount.DeleteAccount(nameForDelete, ibanForDelete);
                        foreach (var item in newList)
                        {
                            Console.WriteLine($"{item.Name}");
                            Console.WriteLine($"{item.IBAN}");
                            Console.WriteLine($"{item.Amount}");
                            Console.WriteLine($"{item.Adress}" + Environment.NewLine);
                        }

                        break;
                    case 'f':
                        AccountList newAccount = new AccountList();
                        var sortedList = newAccount.ordonatedList();
                        foreach (var listItem in sortedList)
                        {
                            Console.WriteLine($"{listItem.Name}");
                            Console.WriteLine($"{listItem.IBAN}");
                            Console.WriteLine($"{listItem.Amount}");
                            Console.WriteLine($"{listItem.Adress}" + Environment.NewLine);
                        }

                        break;
                    case 'g':
                        AccountList updateAdressAccount = new AccountList();
                        var updatedList = updateAdressAccount.changeAccount();
                        foreach (var item in updatedList)
                        {
                            Console.WriteLine($"{item.Name}");
                            Console.WriteLine($"{item.IBAN}");
                            Console.WriteLine($"{item.Amount}");
                            Console.WriteLine($"{item.Adress}" + Environment.NewLine);
                        }
                        break;
                    case 'h':
                        Console.Clear();
                        Environment.Exit(0);
                        break;
                }
            }
      
          Console.ReadKey();
        }
    }
}
