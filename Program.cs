﻿namespace Royal_Flush_Casino
{
	internal class Program
	{
		static void Main(string[] args)
		{
			// CHECK if the microsoft coding conventions match

			// Create an instance of the Casino class
			Casino royalFlushCasino = new Casino();

			// create a instance of the player
			Player player = new Player(0); // Assuming initial balance is 0


			// Call the EnterCasino method
			royalFlushCasino.enterCasino(player);
		}
	}
}