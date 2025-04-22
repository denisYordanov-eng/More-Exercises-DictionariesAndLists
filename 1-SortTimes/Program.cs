using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_SortTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            var times = Console.ReadLine().Split(' ').ToList();

            var sortedTimes = times.OrderBy(a => a).ToArray();
            Console.WriteLine(String.Join(", ", sortedTimes));
        }
    }
}
