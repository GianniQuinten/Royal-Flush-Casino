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
			Console.WriteLine("hi there, can i help you?");
			Console.WriteLine($"you now have: {player.Chips} chips");
			Console.WriteLine($"you now have: {player.MoneyOnHand} money on hand");
			Console.WriteLine("1. exchange chips for money");
			Console.WriteLine("2. exchange money for chips");
			Console.WriteLine("3. exit");
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
					Console.WriteLine("thank you for visiting the cashier!");
					// here you might want to go back to the main menu or do something else
					break;
				default:
					Console.WriteLine("invalid choice. please enter a correct number");
					CashierOptions(); // recursively call to handle invalid input
					break;
			}
		}

		private void ExchangeMoneyForChips()
		{
			Console.WriteLine("how much money would you like to exchange for chips?");
			double amount = double.Parse(Console.ReadLine());

			player.Chips += amount;  // using properties for direct access
			player.MoneyOnHand -= amount;
			Console.WriteLine("transaction successful!");
			Console.WriteLine($"you now have: {player.Chips} chips");
			Console.WriteLine($"you now have: {player.MoneyOnHand} money on hand");
			Console.WriteLine("press any key to go back to the cashier options menu...");
			Console.ReadKey();
			Console.Clear();
			CashierOptions();
		}

		private void ExchangeChipsForMoney()
		{
			Console.WriteLine("how many chips would you like to exchange for money?");
			double amount = double.Parse(Console.ReadLine());

			player.Chips -= amount;  // using properties for direct access
			player.MoneyOnHand += amount;
			Console.WriteLine("transaction successful!");
			Console.WriteLine($"you now have: {player.Chips} chips");
			Console.WriteLine($"you now have: {player.MoneyOnHand} money on hand");
			Console.WriteLine("press any key to go back to the cashier options menu...");
			Console.ReadKey();
			Console.Clear();
			CashierOptions();
		}
	}
}
