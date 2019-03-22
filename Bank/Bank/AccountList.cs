using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class AccountList
    {
       public List<Account> accountList = new List<Account>();
        
        public IEnumerable<Account> returnAccountList()
        {
            var accountListreturned = accountList;
            return accountListreturned;
        }
        public void AddAccount(string Name,double Amount,string IBAN,string Adress)
        {

            accountList.Add(new Account(Name,Amount,IBAN,Adress));
            
         
        }
        public IEnumerable<Account> ordonatedList()
        {
            var ordonatedList = accountList.OrderByDescending(x => x.Amount).Take(3);
            return ordonatedList;
        }

        public IEnumerable<Account> DeleteAccount(string Name,string IBAN)
        {
            var itemToRemove = accountList.SingleOrDefault(r => r.Name == Name || r.IBAN == IBAN);
            accountList.Remove(itemToRemove);
            return accountList;
        }

        public IEnumerable<Account> changeAdress()
        {
            Console.WriteLine("Enter the name for changing the adress:");
            string Name = Console.ReadLine();
            Console.WriteLine("Enter the new adress: ");
            string Adress = Console.ReadLine();
            var obj = accountList.FirstOrDefault(c => c.Name == Name);
            if (obj != null) obj.Adress = Adress;
            var updatedList = accountList;
            Console.Clear();
            Console.WriteLine("Your new adress is: "+obj.Adress);
            Console.ReadKey();
            return updatedList;
        }

        public void Deposit(string IBAN, Account Amount)
        {
            Console.WriteLine("Enter the amount for deposit:");
            double amountToDeposit = Convert.ToDouble(Console.ReadLine());
            Amount.Amount += amountToDeposit;
           
            Console.WriteLine("Yout new balance is "+ Amount.Amount);
            Console.ReadKey();
        }

        public Account GetInitialAccount(string IBAN)
        {
            var initialAccount = accountList.SingleOrDefault(r => r.IBAN == IBAN);
            return initialAccount;
        }

        public void GetWithdraw(string IBAN, Account Amount)
        {


            Console.Clear();
            Console.WriteLine("Please enter the withdrawal amount: ");
            double withdrawalAmount = Convert.ToDouble(Console.ReadLine());
            double commision = 0;
            if (withdrawalAmount > Amount.Amount)
            {
                Console.WriteLine("Insufficient funds!");
                //De pus sa se faca loop
            }
            else
            {
                commision = (5d / 100) * withdrawalAmount;
                withdrawalAmount -= commision;
                Amount.Amount = Amount.Amount - withdrawalAmount - commision;// de pus conditie daca toata asta ==0 sa se faca loop

            }
            Console.WriteLine("Yout new balance is " + Amount.Amount+Environment.NewLine+"Your withdrawed amount is: "+ withdrawalAmount+", commision is: "+ commision);
            Console.ReadKey();

        }
    }
}
