using Royal_Flush_Casino.Utility;
using System;

namespace Royal_Flush_Casino.Game
{
    internal class HorseRacing
    {
        public static void BetOnHorseRacing(Player player)
        {
            // Set the bet price to 10 chips per game
            double gameCost = 10;

            bool playAgain = true;

            while (playAgain)
            {
                Console.WriteLine("You chose Horse Racing.");
                Console.WriteLine("Select a horse (1-4): ");
                Console.WriteLine(); // Skip line
                Console.WriteLine($"You currently have: {player.chips} chips, the price to play will be: {gameCost} chips.");
                int horseChoice;
                while (!int.TryParse(Console.ReadLine(), out horseChoice) || horseChoice < 1 || horseChoice > 4)
                {
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 4.");
                    Console.Write("Select a horse (1-4): ");
                }

                Console.WriteLine($"You selected Horse {horseChoice}. The race is about to begin...");
                System.Threading.Thread.Sleep(2000); // Delay for 2 seconds to build anticipation

                // Simulate the race
                Random random = new Random();
                int[] horsePositions = new int[4]; // Array to store the positions of each horse
                int raceDistance = 26; // Total distance of the race
                int finishLine = 25; // Position of the finish line
                int winningHorse = -1; // Initialize winning horse
                while (true)
                {
                    // Move each horse forward randomly
                    for (int i = 0; i < horsePositions.Length; i++)
                    {
                        horsePositions[i] += random.Next(1, 4); // Randomly move horse forward by 1-3 steps

                        // Check if any horse has crossed the finish line
                        if (horsePositions[i] >= finishLine)
                        {
                            winningHorse = i + 1; // Set the winning horse
                            break;
                        }
                    }

                    // Display race progress
                    Console.Clear();
                    Console.WriteLine("Race is on!");
                    Console.WriteLine($"You bet on Horse: {horseChoice}");
                    for (int i = 0; i < horsePositions.Length; i++)
                    {
                        Console.Write($"Horse {i + 1}: ");
                        for (int j = 0; j < raceDistance; j++)
                        {
                            if (j == horsePositions[i])
                            {
                                Console.Write("🐎"); // Display the horse
                            }
                            else if (j == finishLine)
                            {
                                Console.Write("|"); // Display the finish line
                            }
                            else
                            {
                                Console.Write("-"); // Display the track
                            }
                        }
                        Console.WriteLine();
                    }

                    System.Threading.Thread.Sleep(500); // Delay for 0.5 seconds between each step of the race

                    // Check if a horse has won
                    if (winningHorse != -1)
                    {
                        break; // Exit the loop if a horse has won
                    }
                }

                // Determine the winner
                Console.WriteLine();
                Console.WriteLine($"Horse {winningHorse} wins the race!");

                // Check if user's horse matches the winning horse@
                if (horseChoice == winningHorse)
                {
                    Console.WriteLine("Congratulations! You win!");
                    player.chips += gameCost * 2.5;
                }
                else
                {
                    Console.WriteLine("Sorry! You lose!");
                    player.chips -= gameCost;
                }

                // Offer options to the user
                string choice;
                do
                {
                    Console.WriteLine($"You currently have: {player.chips} chips!");
                    Console.WriteLine(); // Skip a line
                    Console.WriteLine("1. Play again");
                    Console.WriteLine("2. Go back to sports betting");
                    Console.WriteLine("3. Exit the Casino");
                    Console.Write("Enter your choice: ");
                    choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            break; // The loop will continue for playing again
                        case "2":
                            playAgain = false;
                            GameSelector.SportBettingMain(player);
                            break;
                        case "3":
                            System.Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine();
                            Console.WriteLine("Invalid choice. Please use 1, 2, or 3.");
                            break;
                    }
                } while (choice != "1" && choice != "2" && choice != "3");
            }
        }
    }
}
