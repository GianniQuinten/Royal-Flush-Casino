using System;

namespace Royal_Flush_Casino
{
	public class Cashier
	{
		public Player player;

		public Cashier(Player player)
		{
			this.player = player;
		}

		public void CashierOptions()
		{
			Console.WriteLine("Hi there can I help you?");
			Console.WriteLine($"You now have: {player.Chips} chips");
			Console.WriteLine($"You now have: {player.MoneyOnHand} money on hand");
			Console.WriteLine("1. Exchange chips for money");
			Console.WriteLine("2. Exchange money for chips");
			Console.WriteLine("3. Exit");
			string cashierChoice = Console.ReadLine();

			switch (cashierChoice)
			{
				case "1":
					ExchangeMoneyForChips();
					break;
				case "2":
					ExchangeChipsForMoney();
					break;
				case "3":
					Console.WriteLine("Thank you for visiting the cashier!");
					// Here you might want to go back to the main menu or do something else
					break;
				default:
					Console.WriteLine("Invalid choice. Please enter a correct number");
					CashierOptions(); // Recursively call to handle invalid input
					break;
			}
		}

		private void ExchangeMoneyForChips()
		{
			Console.WriteLine("How much money would you like to exchange for chips? ");
			double amount = Double.Parse(Console.ReadLine());

			player.Chips += amount;  // Using properties for direct access
			player.MoneyOnHand -= amount;
			Console.WriteLine("Transaction successful!");
			Console.WriteLine($"You now have: {player.Chips} chips");
			Console.WriteLine($"You now have: {player.MoneyOnHand} money on hand");
			Console.WriteLine("Press any key to go back to the Cashier options menu...");
			Console.ReadKey();
			Console.Clear();
			CashierOptions();
		}

		private void ExchangeChipsForMoney()
		{
			Console.WriteLine("How many chips would you like to exchange for money? ");
			double amount = Double.Parse(Console.ReadLine());

			player.Chips -= amount;  // Using properties for direct access
			player.MoneyOnHand += amount;
			Console.WriteLine("Transaction successful!");
			Console.WriteLine($"You now have: {player.Chips} chips");
			Console.WriteLine($"You now have: {player.MoneyOnHand} money on hand");
			Console.WriteLine("Press any key to go back to the Cashier options menu...");
			Console.ReadKey();
			Console.Clear();
			CashierOptions();
		}
	}

}
