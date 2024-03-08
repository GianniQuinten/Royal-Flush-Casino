using System;
using System.Collections.Generic;
using System.Threading;

namespace Royal_Flush_Casino.Game
{
    internal class Football
    {
        public static void BetOnFootball()
        {
            // Sample list of 20 football teams
            List<string> teams = new List<string>
            {
                "Almere City", "Ajax", "PSV", "Feyenoord", "AZ",
                "Manchester City", "Liverpool", "Arsenal", "Manchester United", "Chelsea"
            };

            // Select teams
            Console.WriteLine("Select two teams to play:");

            for (int i = 0; i < teams.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {teams[i]}");
            }

            Console.Write("Enter the number of the first team: ");
            int teamIndex1 = int.Parse(Console.ReadLine()) - 1;
            Console.Write("Enter the number of the second team: ");
            int teamIndex2 = int.Parse(Console.ReadLine()) - 1;

            string teamA = teams[teamIndex1];
            string teamB = teams[teamIndex2];

            // Clear console
            Console.Clear();

            // Simulate match
            Random random = new Random();

            int minutes = 0;
            int goalsA = 0;
            int goalsB = 0;

            int goalLine = 3; // Starting line for goal messages

            // Kick Off!
            Console.SetCursorPosition(0, goalLine);
            Console.WriteLine("Kick Off!");
            goalLine++;

            while (minutes <= 90)
            {
                // Clear lines
                Console.SetCursorPosition(0, 1);
                Console.Write(new string(' ', Console.WindowWidth - 1)); // Clear score line
                Console.SetCursorPosition(0, 2);

                // Update score
                Console.SetCursorPosition(0, 0);
                Console.WriteLine($"Match: {teamA} {goalsA} - {goalsB} {teamB}");

                // Update minute
                Console.SetCursorPosition(0, 1);
                Console.Write($"Minute: {minutes}'");

                // Simulate events like goals
                if (random.Next(100) < 3) // 3% chance of a goal in any minute
                {
                    string scoringTeam = random.Next(2) == 0 ? teamA : teamB;
                    if (scoringTeam == teamA)
                    {
                        goalsA++;
                    }
                    else
                    {
                        goalsB++;
                    }

                    Console.SetCursorPosition(0, goalLine);
                    Console.WriteLine($"GOAL! {scoringTeam} scored in the {minutes}th minute!");
                    goalLine++; // Move to the next line for the next goal message
                }

                // Half Time
                if (minutes == 45)
                {
                    goalLine = goalLine + 1;
                    Console.SetCursorPosition(0, goalLine);
                    Console.WriteLine($"Half Time! {teamA} {goalsA} - {goalsB} {teamB}");
                    goalLine++;
                }

                // Kick Off! Second Half begins!
                if (minutes == 46)
                {
                    goalLine = goalLine + 1;
                    Console.SetCursorPosition(0, goalLine);
                    Console.WriteLine("Kick Off! Second Half begins!");
                    goalLine++;
                }

                Thread.Sleep(300);
                minutes++;
            }

            // Display match result
            Console.SetCursorPosition(0, goalLine);
            Console.WriteLine("\nFull Time!");
            Console.WriteLine($"Match: {teamA} {goalsA} - {goalsB} {teamB}");
        }
    }
}
