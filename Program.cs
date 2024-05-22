using Royal_Flush_Casino.Game;
using Royal_Flush_Casino.Utility;
using System;

namespace Royal_Flush_Casino
{
	internal class Program
	{
		static void Main(string[] args)
		{
			// ensure that the slot wheel icons are displayed correctly
			Console.OutputEncoding = System.Text.Encoding.UTF8;

			// create an instance of the Casino class
			Casino royalFlushCasino = new Casino();

			// create an instance of the Player class with a balance of 0 euros, 500 euros on hand, and 150 chips
			Player player = new Player(0, 500, 150);

			// display the welcome title and message
			WelcomeTitle.DisplayTitle();
			WelcomeTitle.DisplayWelcome();

			// call the EnterCasino method
			royalFlushCasino.EnterCasino(player);
		}
	}
}
