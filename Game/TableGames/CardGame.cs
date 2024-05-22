using System;

namespace Royal_Flush_Casino.Game
{
    internal abstract class CardGame
    {
        protected static Random random = new Random();

        // Array of card suits
        protected static string[] suits = { "♥", "♦", "♣", "♠" };

        // Array of card faces
        protected static string[] faces = { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };

        // Method to start the game loop
        public abstract void PlayGame(Player player);

        // Method to get a bet from the player
        protected abstract double GetBet(double playerChips);

        // Method to deal an initial hand of cards
        protected abstract string[] DealInitialHand();

        // Method to deal a single card
        protected string DealCard()
        {
            int suitIndex = random.Next(suits.Length);
            int faceIndex = random.Next(faces.Length);
            return faces[faceIndex] + suits[suitIndex];
        }

        // Method to convert a hand to a string
        protected string HandToString(string[] hand)
        {
            return string.Join(" ", hand);
        }
    }
}
