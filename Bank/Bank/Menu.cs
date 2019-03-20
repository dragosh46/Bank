using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class Menu
    {
        public char PrincipalMenu(ref char action)
        {
            Console.Clear();
            Console.WriteLine("a. Create account");
            Console.WriteLine("b. Deposit");
            Console.WriteLine("c. Withdraw");
            Console.WriteLine("d. Display sold");
            Console.WriteLine("e. Exit");
            
            return action;
        }
    }
}
