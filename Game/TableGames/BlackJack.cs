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

                        // When you start a game clear the console so you have a clear working space for the game to play on
                        Console.Clear();

                        Console.WriteLine("Shuffling the deck...");
                        Console.WriteLine("Done shuffling the deck.");
                        Console.WriteLine("Serving the cards");
                        // Whitespace line
                        Console.WriteLine();

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
        private static string[] DealInitialHand(Random randomGenerator)
        {
            string[] hand = new string[2];
            hand[0] = DealCard(randomGenerator);
            hand[1] = DealCard(randomGenerator);
            return hand;
        }

        // These are all the cards we are using in BlackJack.
        private static string[] suits = { "\u2665", "\u2666", "\u2663", "\u2660" }; // Hearts, Diamonds, Clubs, Spades
        private static string[] faces = { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" }; // Ace, 2-10, Jack, Queen, King

        private static string DealCard(Random randomGenerator)
        {
            int suitIndex = randomGenerator.Next(0, suits.Length);
            int faceIndex = randomGenerator.Next(0, faces.Length);
            string card = faces[faceIndex] + suits[suitIndex];
            return card;
        }


        private static string HandToString(string[] hand)
        {
            string handString = "";
            foreach (string card in hand)
            {
                handString += card + " ";
            }
            return handString.Trim();
        }
    }
}