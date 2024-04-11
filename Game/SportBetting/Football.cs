using Royal_Flush_Casino.Utility;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Royal_Flush_Casino.Game
{
    // Abstract class for matches
    internal abstract class Match
    {
        protected List<string> Teams { get; set; }
        protected Random Random { get; set; }

        public abstract void Play(Player player);
    }

    // Concrete class for football matches
    internal class FootballMatch : Match
    {
        // Set the bet price to 10 chips per game
        private double gameCost = 10;

        public FootballMatch()
        {
            Teams = new List<string>
            {
                "Almere City", "Ajax", "PSV", "Feyenoord", "AZ",
                "Manchester City", "Liverpool", "Arsenal", "Manchester United", "Chelsea"
            };
            Random = new Random();
        }

        public override void Play(Player player)
        {
            bool playAgain = true;

            while (playAgain)
            {
                Console.Clear();

                // Select teams randomly
                int teamIndex1 = Random.Next(Teams.Count);
                int teamIndex2 = Random.Next(Teams.Count);

                while (teamIndex1 == teamIndex2) // Ensure both teams are different
                {
                    teamIndex2 = Random.Next(Teams.Count);
                }

                string teamA = Teams[teamIndex1];
                string teamB = Teams[teamIndex2];

                // Betting
                string choiceText;
                string chosenBet = "";
                do
                {
                    // Display match information
                    Console.WriteLine($"Match: {teamA} vs {teamB}\n");
                    Console.WriteLine("Place your bet:");
                    Console.WriteLine($"1. {teamA} wins");
                    Console.WriteLine("2. Draw");
                    Console.WriteLine($"3. {teamB} wins");
                    Console.WriteLine("4. Go back to Sportbetting");

                    Console.WriteLine();
                    Console.WriteLine($"You currently have: {player.chips} chips, the price to play will be: {this.gameCost} chips.");
                    Console.Write("Enter your choice: ");
                    choiceText = Console.ReadLine();

                    switch (choiceText)
                    {
                        case "1":
                            chosenBet = teamA + " wins";
                            player.chips -= this.gameCost;
                            break;
                        case "2":
                            chosenBet = "Draw";
                            player.chips -= this.gameCost;
                            break;
                        case "3":
                            chosenBet = teamB + " wins";
                            player.chips -= this.gameCost;
                            break;
                        case "4":
                            Console.Clear();
                            GameSelector.SportBettingMain(player);
                            break;
                        default:
                            chosenBet = "Invalid choice";
                            Console.Clear();
                            Console.WriteLine("Please enter a valid choice (1, 2, or 3).");
                            break;
                    }
                } while (choiceText != "1" && choiceText != "2" && choiceText != "3");

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
                    Console.WriteLine($"You bet on: {chosenBet}");


                    // Simulate events like goals
                    if (Random.Next(100) < 3) // 3% chance of a goal in any minute
                    {
                        string scoringTeam = Random.Next(2) == 0 ? teamA : teamB;
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
                    if (goalsA > goalsB) // If the chosen team wins
                    {
                        player.chips += this.gameCost * 2; // Award double the bet amount
                    }
                }
                else if (choiceText == "2")
                {
                    betOutcome = goalsA == goalsB ? "You win!" : "You lose!";
                    if (goalsA == goalsB) // If it's a draw
                    {
                        player.chips += this.gameCost * 2; // Award double the bet amount
                    }
                }
                else if (choiceText == "3")
                {
                    betOutcome = goalsA < goalsB ? "You win!" : "You lose!";
                    if (goalsA < goalsB) // If the chosen team wins
                    {
                        player.chips += this.gameCost * 2.5; // Award double the bet amount
                    }
                }
                else
                {
                    betOutcome = "Invalid choice";
                }

                Console.WriteLine($"Your bet outcome: {betOutcome}");
                Console.WriteLine($"You currently have: {player.chips} chips!");
                Console.WriteLine(); // Skip a line

                Console.WriteLine("1. Play again");
                Console.WriteLine("2. Go back to sports betting");
                Console.WriteLine("3. Exit the Casino");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        playAgain = true;
                        break;
                    case "2":
                        playAgain = false;
                        Console.Clear();
                        GameSelector.SportBettingMain(player);
                        break;
                    case "3":
                        Environment.Exit(0);
                        break;
                    default:
                        playAgain = false;
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }

    internal class Football
    {
        public static void BetOnFootball(Player player)
        {
            Match footballMatch = new FootballMatch();
            footballMatch.Play(player);
        }
    }
}
