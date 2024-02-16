using System;

namespace Royal_Flush_Casino
{
	internal class Casino
	{
		public void enterCasino()
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
					// Add code to handle going to the cashier
					break;
				case "2":
					Console.WriteLine("You have chosen to go to the ATM.");
					atmOptions();
					break;
				default:
					Console.WriteLine("Invalid choice. Please enter either 1 or 2.");
					break;
			}
		}

		public void atmOptions()
		{

			Console.WriteLine("What would you like to do?");
			Console.WriteLine("1. Deposit money");
			Console.WriteLine("2. Withdraw money.");
			Console.WriteLine("3. Show account balance");
			Console.WriteLine("4. Exit");
			string atmChoice = Console.ReadLine();

			switch (atmChoice)
			{
				case "1":
					Console.WriteLine("1. Deposit money");
					// deposit();
					break;
				case "2":
					Console.WriteLine("2. Withdraw money.");
					// withdraw();
					break;
				case "3":
					Console.WriteLine("3. Show account balance");
					// balance();
					break;
				case "4":
					Console.WriteLine("4. Exit");
					enterCasino();
					break;
				default:
					Console.WriteLine("Invalid choice. Please enter a correct number");
					break;
			}
		}

		void deposit(Player playerBalance)
		{
			Console.WriteLine("How much money would you like to deposit? ");
			double deposit = Double.Parse(Console.ReadLine());
			playerBalance.setBalance(deposit);
			Console.WriteLine("Thank you for using our service! Your new balance is: " + playerBalance.getBalance());
		}

		void withdraw(Player playerBalance)
		{
			Console.WriteLine("How much money would you like to withdraw? ");
			double withdrawal = Double.Parse(Console.ReadLine());

			// check if the user does have the right amount to withdraw
			if (playerBalance.getBalance() > withdrawal)
			{
				Console.WriteLine("you dont have enough money! try earning more money");
			}
			else
			{
				playerBalance.setBalance(playerBalance.getBalance() - withdrawal);
			}

			void balance(Player playerBalance)
			{
				Console.Write("Your current balance is: " + playerBalance.getBalance());
			}

			void CashierOptions()
			{
				Console.WriteLine("Hi there can I help you?");
				Console.WriteLine("1. Exchange chips for money");
				Console.WriteLine("2. exhange money for chips");
				Console.WriteLine("3. Exit");
			}
		}
	}

	}

	
