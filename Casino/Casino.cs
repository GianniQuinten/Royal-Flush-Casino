using System;
using Royal_Flush_Casino.Game;
using Royal_Flush_Casino.Utility;

namespace Royal_Flush_Casino
{
	public class Casino
	{
		public void EnterCasino(Player player)
		{
			Console.WriteLine("you walk through the doors and see a cashier and an atm.");
			Console.WriteLine("what do you want to do?");
			Console.WriteLine("1. go to the cashier");
			Console.WriteLine("2. go to the atm");
			Console.WriteLine("3. go gambling");

			string? playerChoiceEntrance = Console.ReadLine();

			if (playerChoiceEntrance == null)
			{
				Console.WriteLine("invalid input. please enter either 1, 2, or 3.");
				EnterCasino(player);  // recursive call to re-prompt the user
				return;
			}

			switch (playerChoiceEntrance)
			{
				case "1":
					Cashier cashier = new Cashier(player);
					cashier.CashierOptions();
					break;
				case "2":
					ATM atm = new ATM(player);  // create an instance of atm
					atm.AtmOptions();           // correctly reference the method using the right case and without passing player again
					break;
				case "3":
					StartGame(player);
					break;
				default:
					Console.WriteLine("invalid choice. please enter either 1, 2, or 3.");
					EnterCasino(player);  // recursive call to re-prompt the user
					break;
			}
		}

		void StartGame(Player player)
		{
			Console.WriteLine("you wander through the gambling halls.");
			Console.WriteLine("you see tons of gambling tables and machines.");
			Console.WriteLine("what would you like to do?");
			Console.WriteLine("1. walk to the slot machines.");
			Console.WriteLine("2. walk to the sport betting section.");
			Console.WriteLine("3. walk to the table games section.");
			string? gameModeSelector = Console.ReadLine();

			if (gameModeSelector == null)
			{
				Console.WriteLine("invalid choice. please enter a correct number");
				StartGame(player);  // recursive call to re-prompt the user
				return;
			}

			switch (gameModeSelector)
			{
				case "1":
					Console.WriteLine("you walk to the slot machines.");
					NavigateToSlotmachines(player);
					break;
				case "2":
					Console.WriteLine("you walk to the sport betting section.");
					NavigateToSportBetting(player);
					break;
				case "3":
					Console.WriteLine("you walk to the table games");
					NavigateToTableGames(player);
					break;
				default:
					Console.WriteLine("invalid choice. please enter a correct number");
					StartGame(player);  // recursive call to re-prompt the user
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
