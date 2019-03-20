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

             AccountList CreateNewAccount = new AccountList();
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
                        
                        double initialAmount = CreateNewAccount.GetInitialAmount(depositIBAN);
                        CreateNewAccount.Deposit(depositIBAN, initialAmount);

                        action = 'm';

                        break;
                    case 'c':
                        Console.Clear();
                        Withdraw withdraw = new Withdraw();
                        Console.WriteLine("Enter the IBAN: ");
                        string withdrawIBAN = Console.ReadLine();
                        double initialWithdrawAmount = CreateNewAccount.GetInitialAmount(withdrawIBAN);
                        withdraw.GetWithdraw(withdrawIBAN, ref initialWithdrawAmount);
                        action = 'm';
                        break;
                    case 'd':
                        Console.Clear();
                        Console.WriteLine("Enter the IBAN: ");
                        string soldIBAN = Console.ReadLine();
                        double soldAmount = CreateNewAccount.GetInitialAmount(soldIBAN);
                        Console.WriteLine("Your balance is: "+soldAmount);

                        action = 'm';
                        break;

                    case 'e':
                        Console.Clear();
                        Console.WriteLine("Enter the name for deleting the account:");
                        string nameForDelete = Console.ReadLine();
                        Console.WriteLine("Enter the IBAN for deleting the account:");
                        string ibanForDelete = Console.ReadLine();
                        var newList = CreateNewAccount.DeleteAccount(nameForDelete, ibanForDelete);
                        foreach (var item in newList)
                        {
                            Console.WriteLine($"{item.Name}");
                            Console.WriteLine($"{item.IBAN}");
                            Console.WriteLine($"{item.Amount}");
                            Console.WriteLine($"{item.Adress}" + Environment.NewLine);
                        }
                        action = 'm';
                        break;
                    case 'f':
                        
                        var sortedList = CreateNewAccount.ordonatedList();
                        foreach (var listItem in sortedList)
                        {
                            Console.WriteLine($"{listItem.Name}");
                            Console.WriteLine($"{listItem.IBAN}");
                            Console.WriteLine($"{listItem.Amount}");
                            Console.WriteLine($"{listItem.Adress}" + Environment.NewLine);
                        }
                        action = 'm';
                        break;
                    case 'g':
                        
                        var updatedList = CreateNewAccount.changeAccount();
                        foreach (var item in updatedList)
                        {
                            Console.WriteLine($"{item.Name}");
                            Console.WriteLine($"{item.IBAN}");
                            Console.WriteLine($"{item.Amount}");
                            Console.WriteLine($"{item.Adress}" + Environment.NewLine);
                        }
                        action = 'm';
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
