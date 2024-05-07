using System;
using System.Numerics;
using Royal_Flush_Casino.Game;
using Royal_Flush_Casino.Game.Slotmachine;
// Ensure you include all necessary using directives for your game namespaces

namespace Royal_Flush_Casino.Utility
{
	internal class GameSelector
	{
		// Method to select and play slot machine games
		public static void ChooseSlotMachine(Player player)
		{
			Console.WriteLine("Welcome to the Slot Machine!");

			// displays options
			Console.WriteLine("Choose the slot machine you want to use:");
			Console.WriteLine("1. Fruit SlotMachine");
			Console.WriteLine("2. Space Slotmachine");
			Console.WriteLine("3. Candy Slotmachine");
			Console.WriteLine("4. Fantasy Slotmachine");
			Console.WriteLine("5. Wildwest Slotmachine");
			Console.WriteLine("6. Exit");

			// reads the player's choice/input
			string slotMachineSelector = Console.ReadLine();

			// a switch case to handle the player's selection
			switch (slotMachineSelector)
			{
				case "1":
					Console.WriteLine("Trigger Fruit.");
					FruitSlotMachine fruitSlotMachine = new FruitSlotMachine();
					fruitSlotMachine.Play(player);
					break;
				case "2":
					Console.WriteLine("Trigger Space");
					SpaceSlotMachine spaceSlotMachine = new SpaceSlotMachine();
					spaceSlotMachine.Play(player);
					break;
				case "3":
					Console.WriteLine("Trigger Candy");
					CandySlotMachine candySlotMachine = new CandySlotMachine();
					candySlotMachine.Play(player);
					break;
				case "4":
					Console.WriteLine("Trigger Fantasy");
					FantasySlotMachine fantasySlotMachine = new FantasySlotMachine();
					fantasySlotMachine.Play(player);
					break;
				case "5":
					Console.WriteLine("Trigger Wildwest");
					WildWestSlotMachine wildWestSlotMachine = new WildWestSlotMachine();
					wildWestSlotMachine.Play(player);
					break;
				case "6":
					// Call the method in the Casino class to return to the main casino interface
					Console.Clear();
					Casino casino = new Casino();
					casino.EnterCasino(player);
					break;
				default:
					Console.WriteLine("Invalid choice. Please enter a correct number");
					ChooseSlotMachine(player); // Optionally, recall the method for another chance
					break;
			}
		}

		// Method to select and engage in sports betting
		public static void SportBettingMain(Player player)
		{
			Console.WriteLine("Welcome to Sports Betting!");

			// Display sports options
			Console.WriteLine("Choose the sport you want to bet on:");
			Console.WriteLine("1. Football");
			Console.WriteLine("2. Horse Racing");
            Console.WriteLine("3. Go back to the Casino Menu");

            // Get user's choice of sport
            Console.Write("Enter your choice (1/2/3): ");
			int sportChoice;
			while (!int.TryParse(Console.ReadLine(), out sportChoice) || sportChoice < 1 || sportChoice > 3)
			{
				Console.WriteLine("Invalid choice. Please enter 1, 2 or 3.");
				Console.Write("Enter your choice (1/2/3): ");
			}

			// Call method based on user's choice of sport
			switch (sportChoice)
			{
				case 1:
					Football.BetOnFootball(player);
					break;
				case 2:
                    HorseRacing.BetOnHorseRacing(player);
					break;
				case 3:
                    Console.Clear();
                    Casino casino = new Casino();
                    casino.EnterCasino(player);
                    break;
            }
		}

		public static void ChooseTableGame(Player player)
		{
			BlackJack.PlayBlackJack(player);
		}

		// Add more game selector methods as needed for different sections of your casino application

	}
}
