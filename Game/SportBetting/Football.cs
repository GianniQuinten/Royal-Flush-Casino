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

            // Select teams randomly
            Random random = new Random();
            int teamIndex1 = random.Next(teams.Count);
            int teamIndex2 = random.Next(teams.Count);

            while (teamIndex1 == teamIndex2) // Ensure both teams are different
            {
                teamIndex2 = random.Next(teams.Count);
            }

            string teamA = teams[teamIndex1];
            string teamB = teams[teamIndex2];

            // Clear console
            Console.Clear();

            // Display match information
            Console.WriteLine($"Match: {teamA} vs {teamB}\n");

            // Betting
            Console.WriteLine("Place your bet:");
            Console.WriteLine($"1. {teamA} wins");
            Console.WriteLine("2. Draw");
            Console.WriteLine($"3. {teamB} wins");
            Console.Write("Enter your choice: ");
            string choiceText = Console.ReadLine();
            string chosenBet;
            switch (choiceText)
            {
                case "1":
                    chosenBet = teamA + " wins";
                    break;
                case "2":
                    chosenBet = "Draw";
                    break;
                case "3":
                    chosenBet = teamB + " wins";
                    break;
                default:
                    chosenBet = "Invalid choice";
                    break;
            }

            // Clear console
            Console.Clear();

            // Simulate match
            int minutes = 0;
            int goalsA = 0;
            int goalsB = 0;

            int lineHeight = 4; // Starting line for goal messages


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

                // Your bet
                Console.SetCursorPosition(0, 2);
                Console.Write($"You bet on: {chosenBet}");

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

                    Console.SetCursorPosition(0, lineHeight);
                    Console.WriteLine($"GOAL! {scoringTeam} scored in the {minutes}th minute!");
                    lineHeight++; // Move to the next line for the next goal message
                }

                if (minutes == 0)
                {
                    // Kick Off!
                    Console.SetCursorPosition(0, lineHeight);
                    Console.WriteLine("Kick Off!\n");
                    lineHeight++;
                }

                // Half Time
                if (minutes == 45)
                {
                    lineHeight++;
                    Console.SetCursorPosition(0, lineHeight);
                    Console.WriteLine($"Half Time! {teamA} {goalsA} - {goalsB} {teamB}");
                    Thread.Sleep(2000); // Pause for 2 seconds
                    lineHeight++;
                }

                // Kick Off! Second Half begins!
                if (minutes == 46)
                {
                    lineHeight++;
                    Console.SetCursorPosition(0, lineHeight);
                    Console.WriteLine("Kick Off! Second Half begins!");
                    lineHeight++;
                }

                Thread.Sleep(250);
                minutes++;
            }

            // Display match result
            Console.SetCursorPosition(0, lineHeight);
            Console.WriteLine("\nFull Time!");
            Console.WriteLine($"Match: {teamA} {goalsA} - {goalsB} {teamB}");

            // Determine outcome based on user's choice
            string betOutcome;
            if (choiceText == "1")
            {
                betOutcome = goalsA > goalsB ? "You win!" : "You lose!";
            }
            else if (choiceText == "2")
            {
                betOutcome = goalsA == goalsB ? "You win!" : "You lose!";
            }
            else if (choiceText == "3")
            {
                betOutcome = goalsA < goalsB ? "You win!" : "You lose!";
            }
            else
            {
                betOutcome = "Invalid choice";
            }

            Console.WriteLine($"Your bet outcome: {betOutcome}");
        }
    }
}
