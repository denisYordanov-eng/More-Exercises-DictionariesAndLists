using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_ImmuneSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> viruses = new List<string>();
            int initialStrength = int.Parse(Console.ReadLine());
            string virus = Console.ReadLine().ToLower();
            int maxHealth = initialStrength;
            while (virus != "end")
            {
                int virusStrenght = CalculateVirusStrengrh(virus);
                int virusTime = virusStrenght * virus.Length;
                if (viruses.Contains(virus))
                {
                    virusTime = (int)(virusTime / 3.0);
                }
                else
                {
                    viruses.Add(virus);
                }
                initialStrength -= virusTime;
                
                Console.WriteLine($"Virus {virus}: {virusStrenght} => {virusTime} seconds");
             
                if (initialStrength <= 0)
                {
                    Console.WriteLine("Immune System Defeated.");
                    return;
                }
                else
                {
                    Console.WriteLine($"{virus} defeated in {CalculateTime(virusTime)}.");
                    Console.WriteLine($"Remaining health: {initialStrength}");
                }
                initialStrength = Math.Min(maxHealth, (int)(initialStrength * 1.2));
               
                virus = Console.ReadLine();
            }
            Console.WriteLine($"Final health: {initialStrength}");
        }
       private static string CalculateTime(int time)
        {
            return time / 60 + "m " + time % 60 + "s";
        }

        private static int CalculateVirusStrengrh(string virus)
        {
            int totalStrength = 0;
            for (int i = 0; i < virus.Length; i++)
            {
                totalStrength += virus[i];
            }
            return (int)(totalStrength / 3.0);
        }
    }
}
