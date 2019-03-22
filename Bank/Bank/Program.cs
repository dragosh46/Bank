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
            

            Console.WriteLine("Enter the bank name:");
            string bankName = Console.ReadLine();

            int action = (int)MenuOptions.Deposit;
            Menu menu = new Menu();
            menu.PrincipalMenu(ref action);

            Console.WriteLine("Choose an action:");
            action = Convert.ToInt32((Console.ReadLine()));

            
            AccountList CreateNewAccount = new AccountList();
            while (action != 8)
            {
               
                
                switch (action)
                {
                    case (int)MenuOptions.ReturnToMenu:
                        Menu menuReturn = new Menu();
                        menuReturn.PrincipalMenu(ref action);

                        Console.WriteLine("Choose an action:");
                        action = Convert.ToInt32(Console.ReadLine());
                        break;

                    case (int)MenuOptions.Create_account:
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

                        action = 0;
                        break;
                    case (int)MenuOptions.Deposit:
                        Console.Clear();
                        Console.WriteLine("Enter the IBAN: ");
                        string depositIBAN = Console.ReadLine();

                        Account depositAccount = CreateNewAccount.GetInitialAccount(depositIBAN);
                        CreateNewAccount.Deposit(depositIBAN, depositAccount);

                        action = 0;
                        break;

                    case (int)MenuOptions.Withdraw:
                        Console.Clear();
                        Withdraw withdraw = new Withdraw();
                        Console.WriteLine("Enter the IBAN: ");
                        string withdrawIBAN = Console.ReadLine();
                        Account withdrawAccount = CreateNewAccount.GetInitialAccount(withdrawIBAN);
                        CreateNewAccount.GetWithdraw(withdrawIBAN, withdrawAccount);
                        
                        action = 0;
                        break;

                    case (int)MenuOptions.DisplaySold:
                        Console.Clear();
                        Console.WriteLine("Enter the IBAN: ");
                        string soldIBAN = Console.ReadLine();
                        Account soldAccount = CreateNewAccount.GetInitialAccount(soldIBAN);
                        Console.WriteLine("Your balance is: "+ soldAccount.Amount);
                        Console.ReadKey();

                        action = 0;
                        break;

                    case (int)MenuOptions.DeleteAccount:
                        Console.Clear();
                        Console.WriteLine("Enter the name for deleting the account:");
                        string nameForDelete = Console.ReadLine();
                        Console.WriteLine("Enter the IBAN for deleting the account:");
                        string ibanForDelete = Console.ReadLine();
                        var newList = CreateNewAccount.DeleteAccount(nameForDelete, ibanForDelete);
                        //foreach (var item in newList)
                        //{
                        //    Console.WriteLine($"{item.Name}");
                        //    Console.WriteLine($"{item.IBAN}");
                        //    Console.WriteLine($"{item.Amount}");
                        //    Console.WriteLine($"{item.Adress}" + Environment.NewLine);
                        //}
                        Console.Clear();
                        Console.WriteLine("The account with: name "+nameForDelete+" and IBAN "+ibanForDelete+" was successfully deleted!");
                        Console.ReadKey();
                        action = 0;
                        break;

                    case (int)MenuOptions.MuchMoneyAccounts:
                        
                        var sortedList = CreateNewAccount.ordonatedList();
                        foreach (var listItem in sortedList)
                        {
                            Console.WriteLine(Environment.NewLine);
                            Console.WriteLine("Name "+$"{listItem.Name}");
                            Console.WriteLine("IBAN "+$"{listItem.IBAN}");
                            Console.WriteLine("Amount"+$"{listItem.Amount}");
                            Console.WriteLine("Adress"+$"{listItem.Adress}" );
                        }
                        Console.ReadKey();
                        action = 0;
                        break;

                    case (int)MenuOptions.UpdateAdress:
                        
                        var updatedList = CreateNewAccount.changeAdress();
                        foreach (var item in updatedList)
                        {
                            Console.WriteLine($"{item.Name}");
                            Console.WriteLine($"{item.IBAN}");
                            Console.WriteLine($"{item.Amount}");
                            Console.WriteLine($"{item.Adress}" + Environment.NewLine);
                        }
                        action = 0;
                        break;

                    case (int)MenuOptions.Exit:
                        Console.Clear();
                        Environment.Exit(0);
                        break;
                }
            }
      
          Console.ReadKey();
        }
    }
}
