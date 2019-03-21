using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class Menu
    {
        public int PrincipalMenu(ref int action)
        {
            Console.Clear();
            Console.WriteLine("1. Create account");
            Console.WriteLine("2. Deposit");
            Console.WriteLine("3. Withdraw");
            Console.WriteLine("4. Display sold");
            Console.WriteLine("5. Delete account");
            Console.WriteLine("6. 3 accounts");
            Console.WriteLine("7. Update adress");
            Console.WriteLine("8. Exit"+Environment.NewLine);
            return action;
        }
    }
}
