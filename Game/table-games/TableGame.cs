using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Royal_Flush_Casino.Game
{
    internal class TableGame
    {
        
        static void blackjack(string[] args)
        {
            const double initialChips = 10.000;
            Random randomGenerator = new Random();

            double playerChips = initialChips;
            string name, favoriteCard, favoriteNumber;

            Console.WriteLine("Please insert your name and press <enter>");
            name = Console.ReadLine();

            Console.WriteLine("Please insert your favorite card");
            favoriteCard = Console.ReadLine();

            Console.WriteLine("Please insert your favorite number");
            favoriteNumber = Console.ReadLine();

            Console.Title = "BLACKJACK";
            Console.WriteLine("Welcome to the Royal Flush Casino!");
            Console.WriteLine("21\u2665BLACKJACK\u2665");
            Console.WriteLine("");
            Console.WriteLine("Welcome " + name);
            Console.WriteLine("Welcome " + playerChips);
            Console.WriteLine("Your favorite card is " + favoriteCard);
            Console.WriteLine("Favorite number is " + favoriteNumber);
            Console.WriteLine("1. New game");
            Console.WriteLine("2. Exit blackjack");

            Console.WriteLine("Please insert a menu number option and press <Enter>");
            string selectMenuOption = Console.ReadLine();

            switch (selectMenuOption)
            {
                case "1":
                    Console.WriteLine("Shuffling the deck...");
                    Console.WriteLine("Done shuffling the deck.");
                    Console.WriteLine("Serving the cards");

                    var firstCardScore = randomGenerator.Next(1, 10);
                    var secondCardScore = randomGenerator.Next(1, 10);
                    var thirdCardScore = randomGenerator.Next(0);

                    Console.WriteLine($"Your first card score is: {firstCardScore}");
                    Console.WriteLine($"Your second card score is: {secondCardScore}");
                    Console.WriteLine("Would you like to get served another card?\n1. Yes 2. No");
                    string shouldDeal = Console.ReadLine();

                    if (shouldDeal == "1")
                    {
                        thirdCardScore = randomGenerator.Next(1, 10);
                        Console.WriteLine($"Your third card score is: {thirdCardScore}");
                    }

                    var totalCardScore = firstCardScore + secondCardScore + thirdCardScore;
                    Console.WriteLine($"Your total score is: {totalCardScore}");

                    if (totalCardScore > 21)
                    {
                        Console.WriteLine("Game over!!!! Press any key to quit");
                        Console.ReadKey();
                        return;
                    }

                    var dealerHand = randomGenerator.Next(10, 21);

                    Console.WriteLine($"Your dealer's total card score is {dealerHand}");
                    if (totalCardScore <= dealerHand)
                    {
                        Console.WriteLine("Game over!!!! Press any key to quit");
                        Console.ReadKey();
                        return;
                    }

                    Console.WriteLine("Congratulations you have won! Press any key to quit");
                    Console.ReadKey();
                    return;

                case "2":
                    Console.WriteLine("Exiting blackjack");
                    return;
            }
        }
    }
}