using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tre_cases_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string mål;
            int afleveringer;

            Console.WriteLine("Hvor mange afleveringer lavede dit hold=");
            afleveringer = Convert.ToInt32(Console.ReadLine());

            if (afleveringer >= 10)
            {
                Console.WriteLine("High Five - Jubel!!!!");
            }
            if (afleveringer < 1)
            {
                Console.WriteLine("Shh");
            }
            Console.WriteLine("Var der mål?");
            mål = Console.ReadLine().ToLower();

            if (mål == "mål")
            {
                Console.WriteLine("Olé Olé Olé");
            }
            else
            {
                Console.WriteLine("...");
            }
            Console.ReadLine();
        }

    }
}