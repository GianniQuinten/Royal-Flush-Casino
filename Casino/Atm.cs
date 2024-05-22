using System;

namespace Royal_Flush_Casino
{
	public class ATM
	{
		public Player player;

		public ATM(Player player)
		{
			this.player = player ?? throw new ArgumentNullException(nameof(player));
		}

		public void AtmOptions()
		{
			bool exit = false;
			while (!exit)
			{
				Console.Clear();
				Console.WriteLine("what would you like to do?");
				Console.WriteLine("1. show account balance");
				Console.WriteLine("2. deposit money");
				Console.WriteLine("3. withdraw money");
				Console.WriteLine("4. exit");
				string? atmChoice = Console.ReadLine();

				if (atmChoice == null)
				{
					Console.WriteLine("invalid input. please enter a correct number.");
					continue; // ask for input again
				}

				switch (atmChoice)
				{
					case "1":
						Balance();
						break;
					case "2":
						Deposit();
						break;
					case "3":
						Withdraw();
						break;
					case "4":
						exit = true;
						break;
					default:
						Console.WriteLine("invalid choice. please enter a correct number.");
						break;
				}
			}
		}

		public void Balance()
		{
			Console.WriteLine($"your balance is: {player.Balance}");
			Console.WriteLine("press any key to go back to the atm options menu...");
			Console.ReadKey();
		}

		public void Deposit()
		{
			Console.WriteLine("how much money would you like to deposit?");
			string? input = Console.ReadLine();

			if (input == null)
			{
				Console.WriteLine("invalid input. please enter a valid amount.");
				Console.ReadKey();
				return;
			}

			if (double.TryParse(input, out double deposit))
			{
				if (deposit > player.MoneyOnHand)
				{
					Console.WriteLine("you do not have enough money to deposit that amount.");
					Console.WriteLine($"your current balance on hand is: {player.MoneyOnHand}");
				}
				else
				{
					player.AddToBalance(deposit);
					player.MoneyOnHand -= deposit;
					Console.WriteLine("deposit successful.");
					Console.WriteLine($"your new balance is: {player.Balance}");
					Console.WriteLine($"you now have: {player.MoneyOnHand} on hand");
				}
			}
			else
			{
				Console.WriteLine("invalid input. please enter a valid amount.");
			}
			Console.WriteLine("press any key to go back to the atm options menu...");
			Console.ReadKey();
		}

		public void Withdraw()
		{
			Console.WriteLine("how much money would you like to withdraw?");
			string? input = Console.ReadLine();

			if (input == null)
			{
				Console.WriteLine("invalid input. please enter a valid amount.");
				Console.ReadKey();
				return;
			}

			if (double.TryParse(input, out double withdrawal))
			{
				try
				{
					player.SubtractFromBalance(withdrawal);
					player.MoneyOnHand += withdrawal;
					Console.WriteLine("withdrawal successful.");
					Console.WriteLine($"your new balance is: {player.Balance}");
					Console.WriteLine($"you now have: {player.MoneyOnHand} on hand");
				}
				catch (InvalidOperationException e)
				{
					Console.WriteLine(e.Message);
				}
			}
			else
			{
				Console.WriteLine("invalid input. please enter a valid amount.");
			}
			Console.WriteLine("press any key to go back to the atm options menu...");
			Console.ReadKey();
		}
	}
}
