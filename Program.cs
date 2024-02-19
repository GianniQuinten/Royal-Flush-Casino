namespace Royal_Flush_Casino
{
	internal class Program
	{
		static void Main(string[] args)
		{
			// CHECK if the microsoft coding conventions match

			// Create an instance of the Casino class
			Casino royalFlushCasino = new Casino();

			// create a instance of the player with a balance of a 0 euro and 500 euro on hand
			Player player = new Player(500, 500);


			// Call the EnterCasino method
			royalFlushCasino.enterCasino(player);
		}
	}
}