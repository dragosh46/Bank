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
       List<Account> accountList = new List<Account>();
        
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

        public IEnumerable<Account> changeAccount()
        {
            Console.WriteLine("Enter the name for changing the adress:");
            string Name = Console.ReadLine();
            Console.WriteLine("Enter the new adress: ");
            string Adress = Console.ReadLine();
            var obj = accountList.FirstOrDefault(c => c.Name == Name);
            if (obj != null) obj.Adress = Adress;
            var updatedList = accountList;
            return updatedList;
        }
        public double Deposit(string IBAN, double Amount)
        {
            Console.WriteLine("Enter the amount for deposit:");
            double amountToDeposit = Convert.ToDouble(Console.ReadLine());
            return Amount += amountToDeposit;
        }

        public double GetInitialAmount(string IBAN)
        {
            var initialAccount = accountList.SingleOrDefault(r => r.IBAN == IBAN);
            double initialAmount = initialAccount.Amount;
            return initialAmount;
        }
        
    }
}
