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

                        // Play the game
                        bool playerBusted = PlayerTurn(randomGenerator, playerHand);

                        // If player has above 21 he gets busted
                        if (playerBusted)
                        {
                            Console.WriteLine("Player busted! You lose.");
                            // You lose your bet becose you lost the game.
                            playerChips -= bet;
                        }
                        else
                        {
                            // It's the dealer's turn
                            DealerTurn(randomGenerator, dealerHand, playerHand);

                            // Determine the winner and adjust player's chips accordingly
                            int playerHandValue = CalculateHandValue(playerHand);
                            int dealerHandValue = CalculateHandValue(dealerHand);

                            if (dealerHandValue > 21 || playerHandValue > dealerHandValue)
                            {
                                Console.WriteLine("Player wins!");
                                playerChips += bet;
                            }
                            else
                            {
                                Console.WriteLine("Dealer wins!");
                                playerChips -= bet;
                            }
                        }

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

        private static bool PlayerTurn(Random randomGenerator, string[] playerHand)
        {
            while (true)
            {
                Console.WriteLine("Do you want to hit? (y/n)");
                string input = Console.ReadLine().ToLower();

                if (input == "y")
                {
                    string newCard = DealCard(randomGenerator);
                    Console.WriteLine("You were dealt: " + newCard);
                    playerHand = AddCardToHand(playerHand, newCard);

                    Console.WriteLine("Your hand: " + HandToString(playerHand));

                    int handValue = CalculateHandValue(playerHand);
                    if (handValue == 21)
                    {
                        Console.WriteLine("You got 21!");
                        return false; // Player stands
                    }
                    else if (handValue > 21)
                    {
                        Console.WriteLine("Busted! You lose.");
                        return true; // Player busted
                    }
                }
                else if (input == "n")
                {
                    return false; // Player stands
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter 'y' or 'n'.");
                }
            }
        }

        private static string[] AddCardToHand(string[] hand, string newCard)
        {
            Array.Resize(ref hand, hand.Length + 1);
            hand[hand.Length - 1] = newCard;
            return hand;
        }

        private static int CalculateHandValue(string[] hand)
        {
            int sum = 0;
            int aceCount = 0;

            foreach (string card in hand)
            {
                int value = 0;
                if (card[0] == 'A')
                {
                    value = 11;
                    aceCount++;
                }
                else if (card[0] == 'J' || card[0] == 'Q' || card[0] == 'K')
                {
                    value = 10;
                }
                else
                {
                    value = int.Parse(card.Substring(0, card.Length - 1));
                }

                sum += value;
            }

            // Adjust the value of aces if the sum exceeds 21
            while (sum > 21 && aceCount > 0)
            {
                sum -= 10;
                aceCount--;
            }

            return sum;
        }

        private static void DealerTurn(Random randomGenerator, string[] dealerHand, string[] playerHand)
        {
            // Display the dealer's hand
            Console.WriteLine("Dealer's hand: " + HandToString(dealerHand));

            // Continue hitting until the dealer's hand value is 17 or higher or smaller than player's hand value
            while (CalculateHandValue(dealerHand) < 17 || CalculateHandValue(dealerHand) < CalculateHandValue(playerHand))
            {
                string newCard = DealCard(randomGenerator);
                Console.WriteLine("Dealer draws: " + newCard);
                dealerHand = AddCardToHand(dealerHand, newCard);
            }

            // Display the final dealer's hand
            Console.WriteLine("Dealer's final hand: " + HandToString(dealerHand));
        }
    }
}