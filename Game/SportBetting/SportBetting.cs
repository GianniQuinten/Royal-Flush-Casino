using System;

namespace Royal_Flush_Casino.Game
{
    internal class SportBetting
    {
        public static void SportBettingMain()
        {
            Console.WriteLine("Welcome to Sports Betting!");

            // Display sports options
            Console.WriteLine("Choose the sport you want to bet on:");
            Console.WriteLine("1. Football");
            Console.WriteLine("2. Basketball");
            Console.WriteLine("3. Horse Racing");

            // Get user's choice of sport
            Console.Write("Enter your choice (1/2/3): ");
            int sportChoice;
            while (!int.TryParse(Console.ReadLine(), out sportChoice) || sportChoice < 1 || sportChoice > 3)
            {
                Console.WriteLine("Invalid choice. Please enter 1, 2, or 3.");
                Console.Write("Enter your choice (1/2/3): ");
            }

            // Call method based on user's choice of sport
            switch (sportChoice)
            {
                case 1:
                    Football.BetOnFootball();
                    break;
                case 2:
                    Basketball.BetOnBasketball();
                    break;
                case 3:
                    HorseRacing.BetOnHorseRacing();
                    break;
            }
        }
    }
}
