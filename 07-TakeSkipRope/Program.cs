using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_TakeSkipRope
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();

            char[] initialLetters = message.ToCharArray();

            char[] letters = initialLetters
                .Where(a => ! char.IsDigit(a)).ToArray();
            int[] numbers = initialLetters
                  .Where(a => char.IsDigit(a))
                  .Select(a => int.Parse(a.ToString()))
                  .ToArray();

            List<int> take = new List<int>();
            List<int> skip = new List<int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                if(i % 2 == 0)
                {
                    take.Add(numbers[i]);
                }
                else
                {
                    skip.Add(numbers[i]);
                }
            }
            int allSkip = 0;
            string allMessage = string.Empty;
            for (int i = 0; i < take.Count; i++)
            {
                int taken = take[i];
                int skippen = skip[i];

                allMessage += new string(letters.Skip(allSkip).Take(taken).ToArray());
                allSkip += taken + skippen;
            }
            Console.WriteLine(allMessage);
        }
    }
}
