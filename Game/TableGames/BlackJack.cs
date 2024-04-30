using System;

namespace Royal_Flush_Casino.Game
{
    internal class BlackJack
    {
        public static void PlayBlackJack(Player player)
        {
            double playerChips = player.chips;

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

                        // Hier gaat uiteindelijk de code komen om te spelen.

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
    }
}
