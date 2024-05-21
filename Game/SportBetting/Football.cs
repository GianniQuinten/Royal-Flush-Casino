using Royal_Flush_Casino.Utility;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Royal_Flush_Casino.Game
{
    internal abstract class Match
    {
        protected List<string> Teams { get; set; }
        protected Random Random { get; set; }

        public abstract void Play(Player player);
    }

    internal class FootballMatch : Match
    {
        private const double GameCost = 10;

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
            while (true)
            {
                Console.Clear();
                var (teamA, teamB) = SelectTeams();
                string chosenBet = GetBetOption(player, teamA, teamB);

                if (chosenBet == "Go back to Sportbetting") break;

                Console.Clear();
                SimulateMatch(teamA, teamB, out int goalsA, out int goalsB, chosenBet, player);

                if (!PostMatchOptions(player)) break;
            }
        }

        private (string, string) SelectTeams()
        {
            int teamIndex1 = Random.Next(Teams.Count);
            int teamIndex2;
            do
            {
                teamIndex2 = Random.Next(Teams.Count);
            } while (teamIndex1 == teamIndex2);

            return (Teams[teamIndex1], Teams[teamIndex2]);
        }

        private string GetBetOption(Player player, string teamA, string teamB)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Match: {teamA} vs {teamB}\n");
                Console.WriteLine("Place your bet:");
                Console.WriteLine($"1. {teamA} wins");
                Console.WriteLine("2. Draw");
                Console.WriteLine($"3. {teamB} wins");
                Console.WriteLine("4. Go back to Sportbetting");
                Console.WriteLine($"\nYou currently have: {player.Chips} chips. The price to play is: {GameCost} chips.");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        choice = teamA + " wins";
                        player.Chips -= GameCost;
                        return choice;
                    case "2":
                        choice = "Draw";
                        player.Chips -= GameCost;
                        return choice;
                    case "3":
                        choice = teamB + " wins";
                        player.Chips -= GameCost;
                        return choice;
                    case "4":
                        Console.Clear();
                        GameSelector.SportBettingMain(player);
                        return choice;
                    default:
                        choice = "Invalid choice";
                        Console.Clear();
                        Console.WriteLine("Please enter a valid choice (1, 2, or 3).");
                        break;
                }
            }
        }

        private void SimulateMatch(string teamA, string teamB, out int goalsA, out int goalsB, string chosenBet, Player player)
        {
            goalsA = 0;
            goalsB = 0;
            int minutes = 0;
            int lineHeight = 4;

            while (minutes <= 90)
            {
                DisplayMatchStatus(teamA, teamB, goalsA, goalsB, minutes, chosenBet, lineHeight);

                if (Random.Next(100) < 3)
                {
                    if (Random.Next(2) == 0) goalsA++;
                    else goalsB++;

                    Console.SetCursorPosition(0, lineHeight);
                    Console.WriteLine($"GOAL! {teamA} {goalsA} - {teamB} {goalsB} at {minutes}'");
                    lineHeight++;
                }

                if (minutes == 0 || minutes == 45 || minutes == 46)
                {
                    Console.SetCursorPosition(0, lineHeight);
                    Console.WriteLine(minutes switch
                    {
                        0 => "Kick Off!",
                        45 => $"Half Time! {teamA} {goalsA} - {goalsB} {teamB}",
                        46 => "Kick Off! Second Half begins!"
                    });
                    lineHeight++;
                }

                Thread.Sleep(250);
                minutes++;
            }

            Console.SetCursorPosition(0, lineHeight);
            Console.WriteLine($"\nFull Time! {teamA} {goalsA} - {goalsB} {teamB}");
            BetOutCome(goalsA, goalsB, chosenBet, player, teamA, teamB);
        }

        private void DisplayMatchStatus(string teamA, string teamB, int goalsA, int goalsB, int minutes, string chosenBet, int lineHeight)
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine($"Match: {teamA} {goalsA} - {goalsB} {teamB}");
            Console.SetCursorPosition(0, 1);
            Console.WriteLine($"Minute: {minutes}'");
            Console.SetCursorPosition(0, 2);
            Console.WriteLine($"You bet on: {chosenBet}");
            Console.SetCursorPosition(0, lineHeight);
        }

        private void BetOutCome(int goalsA, int goalsB, string choice, Player player, string teamA, string teamB)
        {
            string betOutcome = "You lose!";
            if (choice == $"{teamA} wins" && goalsA > goalsB)
            {
                betOutcome = "You win!";
                player.Chips += GameCost * 2.5;
            }
            else if (choice == "Draw" && goalsA == goalsB)
            {
                betOutcome = "You win!";
                player.Chips += GameCost * 2.5;
            }
            else if (choice == $"{teamB} wins" && goalsA < goalsB)
            {
                betOutcome = "You win!";
                player.Chips += GameCost * 2.5;
            }

            Console.WriteLine($"Your bet outcome: {betOutcome}");
            Console.WriteLine($"You currently have: {player.Chips} chips!");
        }

        private bool PostMatchOptions(Player player)
        {
            Console.WriteLine("1. Play again");
            Console.WriteLine("2. Go back to sports betting");
            Console.WriteLine("3. Exit the Casino");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    return true;
                case "2":
                    Console.Clear();
                    GameSelector.SportBettingMain(player);
                    return false;
                case "3":
                    Environment.Exit(0);
                    return false;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    return false;
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
