using System;

namespace Royal_Flush_Casino
{
	internal class Casino
	{
		public void EnterCasino()
		{
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
					AtmOptions();
					break;
				default:
					Console.WriteLine("Invalid choice. Please enter either 1 or 2.");
					break;
			}
		}

		public void AtmOptions()
		{
			Console.WriteLine("What would you like to do?");
			Console.WriteLine("1. Deposit money");
			Console.WriteLine("2. Withdraw money");
			Console.WriteLine("3. Show account balance");
			Console.WriteLine("4. Exit");
		}

		public void CashierOptions()
		{
			Console.WriteLine("Hi there can I help you?");
			Console.WriteLine("1. Exchange chips for money");
			Console.WriteLine("2. exhange money for chips");
			Console.WriteLine("3. Exit");
		}
	}
}
