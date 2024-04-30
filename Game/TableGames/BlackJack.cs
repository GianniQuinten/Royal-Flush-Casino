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
        }
    }
}
