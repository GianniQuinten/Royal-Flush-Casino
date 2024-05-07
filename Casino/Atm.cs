using System;

namespace Royal_Flush_Casino
{
	public class ATM
	{
		public Player player;

		public ATM(Player player)
		{
			this.player = player;
		}

		public void atmOptions()
		{
			Console.WriteLine("What would you like to do?");
			Console.WriteLine("1. Show account balance");
			Console.WriteLine("2. Deposit money");
			Console.WriteLine("3. Withdraw money.");
			Console.WriteLine("4. Exit");
			string atmChoice = Console.ReadLine();

			switch (atmChoice)
			{
				case "1":
					balance();
					break;
				case "2":
					deposit();
					break;
				case "3":
					withdraw();
					break;
				case "4":
					// Exit logic or return to main menu
					break;
				default:
					Console.WriteLine("Invalid choice. Please enter a correct number");
					atmOptions();  // Recursive call
					break;
			}
		}

		public void balance()
		{
			Console.WriteLine("Your balance is: " + player.Balance);
			Console.WriteLine("Press any key to go back to the ATM options menu...");
			Console.ReadKey();
			Console.Clear();
			atmOptions();
		}

		public void deposit()
		{
			Console.WriteLine("How much money would you like to deposit? ");
			double deposit = Double.Parse(Console.ReadLine());

			if (deposit > player.MoneyOnHand)
			{
				Console.WriteLine("You do not have enough money to deposit that amount.");
				Console.WriteLine("Your current balance on hand is: " + player.MoneyOnHand);
			}
			else
			{
				player.AddToBalance(deposit);
				player.MoneyOnHand -= deposit;
				Console.WriteLine("Deposit successful. Your new balance is: " + player.Balance);
				Console.WriteLine("You now have: " + player.MoneyOnHand + " on hand");
			}
			Console.WriteLine("Press any key to go back to the ATM options menu...");
			Console.ReadKey();
			Console.Clear();
			atmOptions();
		}

		public void withdraw()
		{
			Console.WriteLine("How much money would you like to withdraw? ");
			double withdrawal = Double.Parse(Console.ReadLine());

			try
			{
				player.SubtractFromBalance(withdrawal);
				player.MoneyOnHand += withdrawal;
				Console.WriteLine("Withdrawal successful. Your new balance is: " + player.Balance);
				Console.WriteLine("You now have: " + player.MoneyOnHand + " on hand");
			}
			catch (InvalidOperationException e)
			{
				Console.WriteLine(e.Message);
			}
			Console.WriteLine("Press any key to go back to the ATM options menu...");
			Console.ReadKey();
			Console.Clear();
			atmOptions();
		}
	}
	}
