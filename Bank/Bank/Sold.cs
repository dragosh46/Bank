using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class Sold
    {
        public void GetSold(string IBAN, double amount)
        {
            Console.WriteLine("Please enter the IBAN code: ");
            string verifyIBAN = Console.ReadLine();
            if (verifyIBAN == IBAN)
            {
                Console.WriteLine("The balanvce is: "+amount);
            }
            else
            {
                Console.WriteLine("Please contact your bank."); 
            }

        }
    }
}
