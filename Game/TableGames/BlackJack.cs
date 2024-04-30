using System;

namespace Royal_Flush_Casino.Game
{
    internal class BlackJack
    {
        public static void PlayBlackJack(Player player)
        {
            double playerChips = player.chips;
            Random randomGenerator = new Random(); // Initialize random generator

            Console.Title = "BLACKJACK";
            Console.WriteLine("Welcome to the Royal Flush Casino!");
            Console.WriteLine("21\u2665BLACKJACK\u2665");
            Console.WriteLine("");
            Console.WriteLine("Welcome!");
            Console.WriteLine("You have " + playerChips + " chips.");

            while (true)
            {
                Console.WriteLine("1. Start a new game");
                Console.WriteLine("2. Go back to the Casino Menu");
                Console.WriteLine("3. Exit the Casino");
                Console.Write("Enter your choice: ");
                string selectMenuOption = Console.ReadLine();

                switch (selectMenuOption)
                {
                    case "1":
                        if (playerChips <= 0)
                        {
                            Console.WriteLine("You are out of chips. Please buy more chips at the Cashier.");
                            break;
                        }

                        Console.WriteLine("Shuffling the deck...");
                        Console.WriteLine("Done shuffling the deck.");
                        Console.WriteLine("Serving the cards");

                        double bet = GetBet(playerChips);

                        var playerHand = DealInitialHand(randomGenerator);
                        var dealerHand = DealInitialHand(randomGenerator);

                        // Display initial hands
                        Console.WriteLine("Your hand: " + HandToString(playerHand));
                        Console.WriteLine("Dealer's hand: " + HandToString(dealerHand));


                        break;

                    case "2":
                        Console.Clear();
                        Casino casino = new Casino();
                        casino.enterCasino(player);
                        break;
                    case "3":
                        System.Environment.Exit(0);
                        break;
                }
            }
        }
        private static double GetBet(double playerChips)
        {
            // Logic for getting player's bet
            return 0;
        }

        private static int[] DealInitialHand(Random randomGenerator)
        {
            // Logic for dealing initial hand
            return new int[2];
        }

        private static string HandToString(int[] hand)
        {
            // Logic for converting hand to string
            return "";
        }
    }
}