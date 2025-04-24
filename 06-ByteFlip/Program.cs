using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_ByteFlip
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ').ToArray();

            var filterArr = input.Where(a => a.Length == 2)
                .Select(a => new string(a.Reverse().ToArray()))
                .Reverse()
                .ToList();

            string result = string.Concat(filterArr.Select(a =>(char) Convert.ToInt32(a, 16)));

            Console.WriteLine(result);
        }
    }
}
