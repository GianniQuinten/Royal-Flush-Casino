using Royal_Flush_Casino.Utility;

namespace Royal_Flush_Casino
{
	internal class Program
	{
		static void Main(string[] args)
		{
			// CHECK if the microsoft coding conventions match

			// Create an instance of the Casino class
			Casino royalFlushCasino = new Casino();

			// create a instance of the player with a balance of a 0 euro, 500 euro on hand and 150 chips
			Player player = new Player(0, 500, 150);

			Welcometitle.displayTitle();
			Welcometitle.displayWelcome();
			// Call the EnterCasino method
			royalFlushCasino.enterCasino(player);
		}
	}
}