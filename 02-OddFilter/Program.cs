using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace _02_OddFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbersInput = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            int[] evenNumber =
                numbersInput.Where(a => a % 2 == 0).ToArray();

            int[] finalArr = evenNumber
                .Select(a => a >= evenNumber.Average() ? ++a : --a)
                .ToArray();

            Console.WriteLine(String.Join(" ", finalArr));
           
        }
    }
}
