using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoliTheCoder
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
           .Split(' ')
           .ToArray();

            Dictionary<string, List<string>> EventParticipants = new Dictionary<string, List<string>>();
            Dictionary<string, int> peopleCount = new Dictionary<string, int>();
           
            while (true) 
            {
                if (input[0] == "Time")
                {
                    break;
                }
                string party = input[1];

                if (!party.StartsWith("#"))
                {
                    input = Console.ReadLine()
                               .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                               .ToArray();
                    continue;
                }

                if (input.Length > 2)
                {

                    List<string> people = new List<string>();
                  
                    for (int i = 2; i < input.Length; i++)
                    { 

                        string person = input[i];
                        people.Add(person);

                    }

                    people = people.Distinct().ToList();
                    people = people.OrderBy(a => a.Substring(1)).ToList();
                    if (!EventParticipants.ContainsKey(party))
                    {
                        EventParticipants[party] = new List<string>();
                    }
                    EventParticipants[party] = people;

                    int count = people.Count;
                    peopleCount[party] = count;
                }
                else if (input.Length == 2)
                {
                    Console.WriteLine($"{party} - 0");
                }
                input = Console.ReadLine()
                                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                .ToArray();
            }
            var  partyPeopleCount = peopleCount
                .OrderByDescending(a => a.Value);
            

            foreach (var keyValuePair in partyPeopleCount)
            {
                string party = keyValuePair.Key;
                string partyName = keyValuePair.Key.Substring(1);
                int countPeople = keyValuePair.Value;
                Console.WriteLine($"{partyName} - {countPeople}");
                foreach (var personParty in EventParticipants)
                {
                    if (personParty.Key == party)
                    {
                        for (int i = 0; i < personParty.Value.Count; i++)
                        {
                            string human = personParty.Value[i];
                            Console.WriteLine(human);
                        }
                    }
                }
            }
        }
    }
}
