using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class Account
    {
        public Account(string name, double amount, string iBAN, string adress)
        {
            Console.Clear();
            Name = name;
            Amount = amount;
            IBAN = iBAN;
            Adress = adress;
            Console.WriteLine("The account was successfully created. Name: "+Name+" IBAN: "+IBAN);
        }

       public string Name { get; set; }
       public double Amount { get; set; }
       public string IBAN { get; set; }
       public string Adress { get; set; }

       
    }
}
