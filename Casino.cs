using System;
using System.Numerics;

namespace Royal_Flush_Casino
{
	internal class Casino
	{
		public void enterCasino(Player player)
		{
			// fix by exit that the hello message wont display
			Console.WriteLine("Hello!");
			Console.WriteLine("Welcome in Royal Flush Casino!");
			Console.WriteLine("You walk through the doors and see a Cashier and an ATM.");
			Console.WriteLine("What do you want to do?");
			Console.WriteLine("1. Go to the Cashier");
			Console.WriteLine("2. Go to the ATM");

			string playerChoiceEntrance = Console.ReadLine();

			switch (playerChoiceEntrance)
			{
				case "1":
					Console.WriteLine("You have chosen to go to the Cashier.");
					CashierOptions();
					break;
				case "2":
					Console.WriteLine("You have chosen to go to the ATM.");
					atmOptions(player);
					break;
				default:
					Console.WriteLine("Invalid choice. Please enter either 1 or 2.");
					break;
			}
		}

		void CashierOptions()
		{
			Console.WriteLine("Hi there can I help you?");
			Console.WriteLine("1. Exchange chips for money");
			Console.WriteLine("2. exhange money for chips");
			Console.WriteLine("3. Exit");
		}


		public void atmOptions(Player player)
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
					Console.WriteLine("1. Show account balance");
					balance(player);
					break;
				case "2":
					Console.WriteLine("2. Deposit money");
					deposit(player);
					break;
				case "3":
					Console.WriteLine("3. Withdraw money.");
					withdraw(player);
					break;
				case "4":
					Console.WriteLine("4. Exit");
					enterCasino(player);
					break;
				default:
					Console.WriteLine("Invalid choice. Please enter a correct number");
					break;
			}
		}

		public void balance(Player player)
		{
			Console.WriteLine("Your balance is: " + player.getBalance());
			Console.WriteLine("Press any key to go back to the ATM options menu...");
			Console.ReadKey();
			Console.Clear();
			atmOptions(player);
		}

		public void deposit(Player player)
		{
			Console.WriteLine("How much money would you like to deposit? ");
			double deposit = Double.Parse(Console.ReadLine());
			player.setBalance(deposit);
			Console.WriteLine("Thank you for using our service! Your new balance is: " + player.getBalance());
		}

		void withdraw(Player player)
		{
			Console.WriteLine("How much money would you like to withdraw? ");
			double withdrawal = Double.Parse(Console.ReadLine());

			// check if the user does have the right amount to withdraw
			if (player.getBalance() < withdrawal)
			{
				Console.WriteLine("you dont have enough money! try earning more money");
			}
			else
			{
				player.setBalance(player.getBalance() - withdrawal);
				player.setMoneyOnHand(player.getMoneyOnHand() + withdrawal);

				Console.WriteLine("Thank you for using our service! Your new balance is: " + player.getBalance());
				Console.WriteLine("You now have: " + player.getMoneyOnHand() + " on hand");

			}

			void balance(Player playerBalance)
			{
				Console.Write("Your current balance is: " + playerBalance.getBalance());
				balance(playerBalance);
			}
		}
	}

	}

	
