using Royal_Flush_Casino.Game;
using Royal_Flush_Casino.Utility;

namespace Royal_Flush_Casino
{
    internal class Program
	{
		static void Main(string[] args)
		{
			// CHECK if the microsoft coding conventions match!

			//this line will make sure that the slotwheel icons are displayed
			Console.OutputEncoding = System.Text.Encoding.UTF8;

			// Create an instance of the Casino class
			Casino royalFlushCasino = new Casino();

			// create a instance of the player with a balance of a 0 euro, 500 euro on hand and 150 chips
			Player player = new Player(0, 500, 150);

			Welcometitle.DisplayTitle();
			Welcometitle.DisplayWelcome();

			// Call the EnterCasino method
			royalFlushCasino.EnterCasino(player);

		}
	}
}