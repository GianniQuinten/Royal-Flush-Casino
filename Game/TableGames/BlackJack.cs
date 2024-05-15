using System;

namespace Royal_Flush_Casino.Game
{
    internal class BlackJack
    {
        // Random object to generate random numbers, used for card dealing
        private static Random random = new Random();

        // Array of card suits
        private static string[] suits = { "♥", "♦", "♣", "♠" };

        // Array of card faces
        private static string[] faces = { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };

        // Starts the Blackjack game loop where the player can start new games, go back, or exit.
        public static void PlayBlackJack(Player player)
        {
            Console.Clear();
            Console.WriteLine($"Welcome to BLACKJACK!\nYou have {player.Chips} chips.");

            while (true)
            {
                Console.WriteLine("\n1. Start a new game\n2. Go back to the Casino Menu\n3. Exit the Casino");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        if (player.Chips <= 0)
                        {
                            Console.WriteLine("You are out of chips. Please buy more at the Cashier.");
                            continue;
                        }
                        PlayGame(player);
                        break;
                    case "2":
                        Console.Clear();
                        Casino casino = new Casino();
                        casino.EnterCasino(player);
                        break;
                    case "3":
                        Environment.Exit(0); // Exits the application
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
        }

        // Handles the logic for playing a single game of Blackjack.
        private static void PlayGame(Player player)
        {
            Console.Clear();
            double bet = GetBet(player.Chips); // Ask player to make a bet
            var playerHand = DealInitialHand(); // Deal initial hand to player
            var dealerHand = DealInitialHand(); // Deal initial hand to dealer

            Console.WriteLine($"Your hand: {HandToString(playerHand)}\nDealer's hand: {HandToString(dealerHand)}");

            bool playerBusted = PlayerTurn(playerHand); // Player takes their turn
            if (playerBusted)
            {
                Console.WriteLine("Player busted!");
                player.Chips -= bet; // Deduct bet from player's chips
            }
            else
            {
                DealerTurn(dealerHand, CalculateHandValue(playerHand)); // Dealer takes their turn
                int playerHandValue = CalculateHandValue(playerHand);
                int dealerHandValue = CalculateHandValue(dealerHand);

                // Compare hand values to determine the winner
                if (dealerHandValue > 21 || playerHandValue > dealerHandValue)
                {
                    Console.WriteLine("Player wins!");
                    player.Chips += bet; // Add bet to player's chips
                }
                else
                {
                    Console.WriteLine("Dealer wins!");
                    player.Chips -= bet; // Deduct bet from player's chips
                }
            }
            Console.WriteLine($"You now have {player.Chips} chips.");
        }

        // Prompt the player to enter a bet and validate it.
        private static double GetBet(double playerChips)
        {
            while (true)
            {
                Console.Write("Enter your bet: ");
                if (double.TryParse(Console.ReadLine(), out double bet) && bet > 0 && bet <= playerChips)
                    return bet;
                Console.WriteLine($"Invalid bet. Enter a bet between 1 and {playerChips}.");
            }
        }

        // Deals an initial hand of two cards.
        private static string[] DealInitialHand()
        {
            return new string[] { DealCard(), DealCard() };
        }

        // Deals a single card by randomly choosing a suit and a face.
        private static string DealCard()
        {
            int suitIndex = random.Next(suits.Length);
            int faceIndex = random.Next(faces.Length);
            return faces[faceIndex] + suits[suitIndex];
        }

        // Converts an array of card strings into a single string.
        private static string HandToString(string[] hand)
        {
            return string.Join(" ", hand);
        }

        // Manages the player's turn where they can choose to hit (take more cards) or stand.
        private static bool PlayerTurn(string[] hand)
        {
            while (true)
            {
                Console.Write("Do you want to hit? (y/n): ");
                if (Console.ReadLine().Trim().ToLower() == "y")
                {
                    string card = DealCard();
                    Console.WriteLine();
                    Console.WriteLine($"You were dealt: {card}");
                    Array.Resize(ref hand, hand.Length + 1);
                    hand[hand.Length - 1] = card;
                    Console.WriteLine($"Your hand: {HandToString(hand)}");
                    int handValue = CalculateHandValue(hand);
                    if (handValue > 21) return true;
                    if (handValue == 21) return false;
                }
                else
                {
                    return false;
                }
            }
        }

        // Calculates the total value of a hand, accounting for the ace's value as 1 or 11.
        private static int CalculateHandValue(string[] hand)
        {
            int sum = 0, aceCount = 0;
            foreach (string card in hand)
            {
                // If the card is a 'J', 'Q', or 'K', its value is 10, If the card is an 'A', its value is 11
                int value = card[0] == 'A' ? 11 : (card[0] == 'J' || card[0] == 'Q' || card[0] == 'K' ? 10 : int.Parse(card.Substring(0, card.Length - 1)));
                if (card[0] == 'A') aceCount++;
                sum += value;
            }
            while (sum > 21 && aceCount > 0)
            {
                sum -= 10;
                aceCount--;
            }
            return sum;
        }

        // Dealer's turn where they draw cards until they reach a certain hand value.
        private static void DealerTurn(string[] hand, int playerHandValue)
        {
            // Continue hitting until the dealer's hand value is 17 or higher and smaller than player's hand value
            while (CalculateHandValue(hand) < 17 || CalculateHandValue(hand) < playerHandValue)
            {
                string card = DealCard();
                Console.WriteLine();
                Console.WriteLine($"Dealer draws: {card}");
                Array.Resize(ref hand, hand.Length + 1);
                hand[hand.Length - 1] = card;
            }
            Console.WriteLine($"Dealer's final hand: {HandToString(hand)}");
        }
    }
}
