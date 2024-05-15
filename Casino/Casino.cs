using System;
using System.Numerics;
using System.Diagnostics;
using Royal_Flush_Casino.Game;
using Royal_Flush_Casino.Utility;

namespace Royal_Flush_Casino
{
    public class Casino
	{
		public void EnterCasino(Player player)
		{
			Console.WriteLine("You walk through the doors and see a Cashier and an ATM.");
			Console.WriteLine("What do you want to do?");
			Console.WriteLine("1. Go to the Cashier");
			Console.WriteLine("2. Go to the ATM");
			Console.WriteLine("3. Go gambling");

			string playerChoiceEntrance = Console.ReadLine();

			switch (playerChoiceEntrance)
			{
				case "1":
					Cashier cashier = new Cashier(player);
					cashier.CashierOptions();
					break;
				case "2":
					ATM atm = new ATM(player);  // Create an instance of ATM
					atm.atmOptions();           // Correctly reference the method using the right case and without passing player again
					break;

				case "3":
					startGame(player);
					break;
				default:
					Console.WriteLine("Invalid choice. Please enter either 1, 2, or 3.");
					EnterCasino(player);  // Recursive call to re-prompt the user
					break;
			}
		}

		

        void startGame(Player player)
        {
            Console.WriteLine("You wander through the gambling halls.");
            Console.WriteLine("You see tons of gambling tables and machines.");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1. Walk to the slot machines.");
            Console.WriteLine("2. Walk to the sport betting section.");
			Console.WriteLine("3. Walk to the table games section.");
			string gameModeSelector = Console.ReadLine();

            switch (gameModeSelector)
            {
                case "1":
                    Console.WriteLine("You walk to the slot machines.");
					NavigateToSlotmachines(player); 
					break;
                case "2":
                    Console.WriteLine("You walk to the sport betting section.");
                    NavigateToSportBetting(player); 
                    break;
				case "3":
					Console.WriteLine("You walk to the Table Games");
					NavigateToTableGames(player);
					break;
                default:
                    Console.WriteLine("Invalid choice. Please enter a correct number");
                    break;
            }
        }

        void NavigateToSportBetting(Player player)
        {
            SportBetting sportBetting = new SportBetting();
            SportBetting.SportBettingMain(player);
        }

		void NavigateToSlotmachines(Player player)
		{
			GameSelector.ChooseSlotMachine(player);
		}

		void NavigateToTableGames(Player player)
		{
			GameSelector.ChooseTableGame(player);
		}
	}
}

