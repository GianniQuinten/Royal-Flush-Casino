﻿using System;

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
					// Add code to handle going to the ATM
					break;
				default:
					Console.WriteLine("Invalid choice. Please enter either 1 or 2.");
					break;
			}
		}
	}
}