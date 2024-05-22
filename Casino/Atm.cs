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
				Console.WriteLine("What would you like to do?");
				Console.WriteLine("1. Show account balance");
				Console.WriteLine("2. Deposit money");
				Console.WriteLine("3. Withdraw money");
				Console.WriteLine("4. Exit");
				string? atmChoice = Console.ReadLine();

				if (atmChoice == null)
				{
					Console.WriteLine("Invalid input. Please enter a correct number.");
					continue; // Ask for input again
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
						Console.WriteLine("Invalid choice. Please enter a correct number.");
						break;
				}
			}
		}

		public void Balance()
		{
			Console.WriteLine($"Your balance is: {player.Balance}");
			Console.WriteLine("Press any key to go back to the ATM options menu...");
			Console.ReadKey();
		}

		public void Deposit()
		{
			Console.WriteLine("How much money would you like to deposit?");
			string? input = Console.ReadLine();

			if (input == null)
			{
				Console.WriteLine("Invalid input. Please enter a valid amount.");
				Console.ReadKey();
				return;
			}

			if (double.TryParse(input, out double deposit))
			{
				if (deposit > player.MoneyOnHand)
				{
					Console.WriteLine("You do not have enough money to deposit that amount.");
					Console.WriteLine($"Your current balance on hand is: {player.MoneyOnHand}");
				}
				else
				{
					player.AddToBalance(deposit);
					player.MoneyOnHand -= deposit;
					Console.WriteLine("Deposit successful.");
					Console.WriteLine($"Your new balance is: {player.Balance}");
					Console.WriteLine($"You now have: {player.MoneyOnHand} on hand");
				}
			}
			else
			{
				Console.WriteLine("Invalid input. Please enter a valid amount.");
			}
			Console.WriteLine("Press any key to go back to the ATM options menu...");
			Console.ReadKey();
		}

		public void Withdraw()
		{
			Console.WriteLine("How much money would you like to withdraw?");
			string? input = Console.ReadLine();

			if (input == null)
			{
				Console.WriteLine("Invalid input. Please enter a valid amount.");
				Console.ReadKey();
				return;
			}

			if (double.TryParse(input, out double withdrawal))
			{
				try
				{
					player.SubtractFromBalance(withdrawal);
					player.MoneyOnHand += withdrawal;
					Console.WriteLine("Withdrawal successful.");
					Console.WriteLine($"Your new balance is: {player.Balance}");
					Console.WriteLine($"You now have: {player.MoneyOnHand} on hand");
				}
				catch (InvalidOperationException e)
				{
					Console.WriteLine(e.Message);
				}
			}
			else
			{
				Console.WriteLine("Invalid input. Please enter a valid amount.");
			}
			Console.WriteLine("Press any key to go back to the ATM options menu...");
			Console.ReadKey();
		}
	}
}
