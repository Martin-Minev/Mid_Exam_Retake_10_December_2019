using System;
using System.Linq;
using System.Collections.Generic;

namespace ArcheryTournament
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] targets = Console.ReadLine()
                                   .Split("|", StringSplitOptions.RemoveEmptyEntries)
                                   .Select(int.Parse)
                                   .ToArray();
            int heroPoints = 0;
            string input = string.Empty;
            int index = 0;

            while ((input = Console.ReadLine())?.ToUpper() != "GAME OVER")
            {
                string[] infos = input.Split("@");
                string command = infos[0];
                
                if (int.Parse(infos[1]) >= 0 && int.Parse(infos[1]) < targets.Length)
                {

                    switch (command)
                    {
                        case "SHOOT LEFT":
                            int startIndex = int.Parse(infos[1]);
                            int lenght = int.Parse(infos[2]);

                            if (startIndex - lenght < 0)
                            {
                                index = targets.Length - (lenght % targets.Length);
                            }

                            if (targets[index] <= 5)
                            {
                                heroPoints += targets[index];
                                targets[index] = 0;
                            }
                            else if (targets[index] > 5)
                            {
                                targets[index] -= 5;
                                heroPoints += 5;
                            }
                            break;

                        case "SHOOT RIGHT":
                            startIndex = int.Parse(infos[1]);
                            lenght = int.Parse(infos[2]);

                            if (targets[index] <= 5)
                            {
                                heroPoints += targets[index];
                                targets[index] = 0;
                            }
                            else if (targets[index] > 5)
                            {
                                targets[index] -= 5;
                                heroPoints += 5;
                            }

                            break;
                        case "REVERSE":
                            Array.Reverse(targets);
                            break;
                    }
                }
                else
                {
                    continue;
                }

            }
            Console.WriteLine(string.Join("-", targets));
            Console.WriteLine($"Iskren finished the archery tournament with {heroPoints}!");
        }
    }
}

