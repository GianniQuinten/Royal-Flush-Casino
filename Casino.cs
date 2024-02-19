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
			Console.WriteLine("3. Go gambling");

			string playerChoiceEntrance = Console.ReadLine();

			switch (playerChoiceEntrance)
			{
				case "1":
					Console.WriteLine("You have chosen to go to the Cashier.");
					cashierOptions(player);
					break;
				case "2":
					Console.WriteLine("You have chosen to go to the ATM.");
					atmOptions(player);
					break;
				case "3":
					Console.WriteLine("You have chosen to go gambling!");
					atmOptions(player);
					break;
				default:
					Console.WriteLine("Invalid choice. Please enter either 1, 2 or 3.");
					break;
			}
		}

		void cashierOptions(Player player)
		{
			Console.WriteLine("Hi there can I help you?");
			Console.WriteLine("You now have: " + player.getChips() + " chips");
			Console.WriteLine("You now have: " + player.getMoneyOnHand() + " money on hand");
			Console.WriteLine("1. Exchange chips for money");
			Console.WriteLine("2. exhange money for chips");
			Console.WriteLine("3. Exit");
			string cashierChoice = Console.ReadLine();

			switch (cashierChoice)
			{
				case "1":
					Console.WriteLine("1. exchange money for chips");
					exchangeMoneyForChips(player);
					break;
				case "2":
					Console.WriteLine("2. exhange chips for money.");
					exchangeChipsForMoney(player);
					break;
				case "3":
					Console.WriteLine("3. Exit");
					enterCasino(player);
					break;
				default:
					Console.WriteLine("Invalid choice. Please enter a correct number");
					break;
			}
		}

		public void exchangeMoneyForChips(Player player)
		{
			Console.WriteLine("How much money would you like to exhange? ");
			double exchanged = Double.Parse(Console.ReadLine());

			player.setChips(player.getChips() + exchanged);
			player.setMoneyOnHand(player.getMoneyOnHand() - exchanged);
			Console.WriteLine("Thank you and enjoy Royal Flush Casino!");
			Console.WriteLine("You now have: " + player.getChips() + " chips");
			Console.WriteLine("You now have: " + player.getMoneyOnHand() + " money on hand");
			Console.WriteLine("Press any key to go back to the Cashier options menu...");
			Console.ReadKey();
			Console.Clear();
			cashierOptions(player);
		}

		public void exchangeChipsForMoney(Player player)
		{
			Console.WriteLine("How much money would you like to exhange? ");
			double exchanged = Double.Parse(Console.ReadLine());

			player.setChips(player.getChips() - exchanged);
			player.setMoneyOnHand(player.getMoneyOnHand() + exchanged);
			Console.WriteLine("Thank you and enjoy Royal Flush Casino!");
			Console.WriteLine("You now have: " + player.getChips() + " chips");
			Console.WriteLine("You now have: " + player.getMoneyOnHand() + " money on hand");
			Console.WriteLine("Press any key to go back to the ATM options menu...");
			Console.ReadKey();
			Console.Clear();
			cashierOptions(player);
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

			player.setBalance(player.getBalance() + deposit);
			player.setMoneyOnHand(player.getMoneyOnHand() - deposit);
			Console.WriteLine("Thank you for using our service! Your new balance is: " + player.getBalance());
			Console.WriteLine("You now have: " + player.getMoneyOnHand() + " on hand");
			Console.WriteLine("Press any key to go back to the ATM options menu...");
			Console.ReadKey();
			Console.Clear();
			atmOptions(player);
		}

		void withdraw(Player player)
		{
			Console.WriteLine("How much money would you like to withdraw? ");
			double withdrawal = Double.Parse(Console.ReadLine());

			// check if the user does have the right amount to withdraw
			if (player.getBalance() < withdrawal)
			{
				Console.WriteLine("you dont have enough money! try earning more money");
				Console.WriteLine("Press any key to go back to the ATM options menu...");
				Console.ReadKey();
				Console.Clear();
			}
			else
			{
				player.setBalance(player.getBalance() - withdrawal);
				player.setMoneyOnHand(player.getMoneyOnHand() + withdrawal);

				Console.WriteLine("Thank you for using our service! Your new balance is: " + player.getBalance());
				Console.WriteLine("You now have: " + player.getMoneyOnHand() + " on hand");
				Console.WriteLine("Press any key to go back to the ATM options menu...");
				Console.ReadKey();
				Console.Clear();

			}

			
		}
	}

	}

	
