using Royal_Flush_Casino.Utility;
using System;

namespace Royal_Flush_Casino.Game
{
    internal class HorseRacing
    {
        private const double GameCost = 10;
        private const int FinishLine = 25;
        private const int RaceDistance = FinishLine + 1;

        public static void BetOnHorseRacing(Player player)
        {
            bool playAgain = true;

            while (playAgain)
            {
                Console.WriteLine("You chose Horse Racing.");
                int horseChoice = GetChosenHorse(player);

                Console.WriteLine($"You selected Horse {horseChoice}. The race is about to begin...");
                System.Threading.Thread.Sleep(2000); // Delay for anticipation

                int winningHorse = SimulateRace(horseChoice);

                UpdateChips(player, horseChoice, winningHorse);
                playAgain = Replay(player);
            }
        }

        private static int GetChosenHorse(Player player)
        {
            Console.WriteLine(); // Skip line
            Console.WriteLine($"You currently have: {player.Chips} chips, the price to play will be: {GameCost} chips.");
            Console.WriteLine("Select a horse (1-4): ");
            int horseChoice;
            while (!int.TryParse(Console.ReadLine(), out horseChoice) || horseChoice < 1 || horseChoice > 4)
            {
                Console.WriteLine("Invalid choice. Please enter a number between 1 and 4.");
                Console.Write("Select a horse (1-4): ");
            }
            return horseChoice;
        }

        private static int SimulateRace(int horseChoice)
        {
            Random random = new Random();
            int[] horsePositions = new int[4];
            int winningHorse = -1;
            while (winningHorse == -1)
            {
                for (int i = 0; i < horsePositions.Length; i++)
                {
                    horsePositions[i] += random.Next(1, 4);
                    if (horsePositions[i] >= FinishLine)
                    {
                        winningHorse = i + 1;
                        break;
                    }
                }
                DisplayRace(horsePositions, horseChoice);
                System.Threading.Thread.Sleep(500);
            }
            return winningHorse;
        }

        private static void DisplayRace(int[] horsePositions, int horseChoice)
        {
            Console.Clear();
            Console.WriteLine("Race is on!");
            Console.WriteLine($"You bet on Horse: {horseChoice}");
            for (int i = 0; i < horsePositions.Length; i++)
            {
                Console.Write($"Horse {i + 1}: ");
                for (int j = 0; j < RaceDistance; j++)
                {
                    if (j == horsePositions[i])
                        Console.Write("🐎");
                    else if (j == FinishLine)
                        Console.Write("|");
                    else
                        Console.Write("-");
                }
                Console.WriteLine();
            }
        }

        private static void UpdateChips(Player player, int horseChoice, int winningHorse)
        {
            Console.WriteLine();
            Console.WriteLine($"Horse {winningHorse} wins the race!");
            if (horseChoice == winningHorse)
            {
                Console.WriteLine("Congratulations! You win!");
                player.Chips += GameCost * 2.5;
            }
            else
            {
                Console.WriteLine("Sorry! You lose!");
                player.Chips -= GameCost;
            }
        }

        private static bool Replay(Player player)
        {
            string choice;
            do
            {
                Console.WriteLine($"You currently have: {player.Chips} chips!");
                Console.WriteLine(); // Skip a line
                Console.WriteLine("1. Play again");
                Console.WriteLine("2. Go back to sports betting");
                Console.WriteLine("3. Exit the Casino");
                Console.Write("Enter your choice: ");
                choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        return true;
                    case "2":
                        GameSelector.SportBettingMain(player);
                        return false;
                    case "3":
                        System.Environment.Exit(0);
                        return false;
                    default:
                        Console.WriteLine("Invalid choice. Please use 1, 2, or 3.");
                        break;
                }
            } while (true);
        }
    }
}
