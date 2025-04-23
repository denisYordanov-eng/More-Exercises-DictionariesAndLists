using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_ParkingValidation
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, string> dataBase = new Dictionary<string, string>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ').ToArray();
                string command = input[0];
                string userName = input[1];
                

                if(command.ToLower() == "register")
                {
                    string numberList = input[2];
                    var printOutput = RegisterUserName(dataBase, userName, numberList);
                    Console.WriteLine(printOutput);
                }
                else if(command.ToLower() == "unregister")
                {
                    var printMessage = UnregisterUserName(dataBase, userName);
                    Console.WriteLine(printMessage);
                }
            }
            foreach (var item in dataBase)
            {
                string userName = item.Key;
                string number = item.Value;
                Console.WriteLine($"{userName} => {number}");
            }
        }

        private static string UnregisterUserName(Dictionary<string, string> dataBase, string userName)
        {
            if (!dataBase.ContainsKey(userName))
            {
                return string.Format("ERROR: user {0} not found", userName);
            }
            dataBase.Remove(userName);
            return string.Format("user {0} unregistered successfully", userName);
        }

        private static string RegisterUserName(Dictionary<string, string> dataBase, string userName, string numberList)
        {
            if (dataBase.ContainsKey(userName))
            {
                return  "ERROR: already registered with plate number " + numberList;
            }
            else if (!ValidatePlate(numberList))
            {
                return "ERROR: invalid license plate " + numberList;
            }
            else if(dataBase.ContainsValue(numberList))
            {
                return string.Format($"ERROR: license plate {numberList} is busy");
            }
            dataBase[userName] = numberList;
            return string.Format("{0} registered {1} successfully"
                , userName, numberList);
        }

        private static bool ValidatePlate(string numberList)
        {
            bool isValidNumbers = numberList.ToCharArray()
                .Skip(2)
                .Take(4)
                .All(a => char.IsDigit(a));

            bool isValidLetters = numberList.ToCharArray()
                .Take(2)
                .Concat(numberList.ToCharArray().Skip(6).Take(2).ToArray())
                .All(d => char.IsUpper(d));

            return numberList.Length == 8 && isValidNumbers && isValidLetters;
        }
    }
}
