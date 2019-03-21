using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class Withdraw
    {
        public double GetWithdraw(string IBAN,double amount)
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
                    amount = amount - withdrawalAmount-commision;// de pus conditie daca toata asta ==0 sa se faca loop
                   
                }
            Console.WriteLine("Yout new balance is " + amount);
            Console.ReadKey();
            return amount;
        }
    }
}
