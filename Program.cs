using Royal_Flush_Casino.Game;
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
			/*royalFlushCasino.enterCasino(player);*/


			// Create an instance of SportBetting
			SportBetting sportBetting = new SportBetting();

			// Call the PrintMessage method
			sportBetting.PrintMessage();

			// quinten even voor jou (wist dit ook niet precies
			// als je een class aanroept die niet static is dan maak je eerst een instance zoals hier
			// wat ik zei over gebruik gwn print message werkt alleen als je expliciet aangeeft dat de method (dit geval sportbetting) static is.
			// als je die create instance dus weghaalt en je zet public static void neer bij sportbetting dan werkt dat
		}
	}
}