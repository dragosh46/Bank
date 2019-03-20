using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class Withdraw
    {
        public void GetWithdraw(string IBAN, ref double amount)
        {
            Console.WriteLine("Please enter the IBAN code: ");
            string verifyIBAN = Console.ReadLine();
            if (verifyIBAN == IBAN)
            {
                Console.Clear();
                Console.WriteLine("Please enter the withdrawal amount: ");
                double withdrawalAmount = Convert.ToDouble(Console.ReadLine());
                if (withdrawalAmount > amount)
                {
                    Console.WriteLine("Insufficient funds!");
                    //De pus sa se faca loop
                }
                else
                {
                    double commision = (5d / 100)*withdrawalAmount;
                    withdrawalAmount -= commision;
                    amount = amount - withdrawalAmount;// de pus conditie daca toata asta ==0 sa se faca loop
                   
                }
            }
            else
            {
                Console.WriteLine("Please contact your bank.");
            }
        }
    }
}
