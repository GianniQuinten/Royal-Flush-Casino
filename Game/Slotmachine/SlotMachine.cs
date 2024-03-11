using Royal_Flush_Casino.Game.Slotmachine;
using System;
using System.Numerics;
using static System.Reflection.Metadata.BlobBuilder;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Royal_Flush_Casino.Game
{
	// defines the base for a slotmachine game
	internal class SlotMachine
    {
		// protected array of slot symbols for inheritance
		protected string[][] slots;

		// The cost to play a single spin on this slot machine. This can be overridden by other slotmachine classes.
		protected double spinCost;

		// selector to choose slotmachine
		public static void ChooseSlotMachine(Player Player) 
        {
			Console.WriteLine("Welcome to slotmachine!");

			// displays options
			Console.WriteLine("Choose the slotmachine you want to use:");
			Console.WriteLine("1. FruitSlotMachine");
			Console.WriteLine("2. SpaceSlotMachine");
			Console.WriteLine("3. Exit");

			// reads the player's choice/input
			string slotMachineSelector = Console.ReadLine();

			// a switchcase to handle the player's selection
			switch (slotMachineSelector)
			{
				case "1":
					Console.WriteLine("Trigger Fruit.");
					FruitSlotMachine fruitSlotMachine = new FruitSlotMachine();
					fruitSlotMachine.Play(Player);
					break;
				case "2":
					Console.WriteLine("Trigger Space");
					SpaceSlotMachine spaceSlotMachine = new SpaceSlotMachine();
					spaceSlotMachine.Play(Player);
					break;
				case "3":
					Console.WriteLine("Exit");
					// Ensure this method is called correctly
					break;
				default:
					Console.WriteLine("Invalid choice. Please enter a correct number");
					break;
			}
		}

		// Constructor that initializes/makes a setup of the base slot symbols
		public SlotMachine()
        {
            // this are the base slotmachine symbols
            slots = new string[][]
            {
                new string[] { "🍒", "🍇", "🍓", "🍉" },
                new string[] { "🍒", "🍇", "🍓", "🍉" },
                new string[] { "🍒", "🍇", "🍓", "🍉" }
            };
        }

		// this is the  Play method logic that can be used by other slotmachines
		public virtual void Play(Player player)
		{
			// we use this to randomise 
			Random random = new Random();
			int numberOfReels = 3; // how many reels/wheels the slotmachines has
			int numberOfSymbols = 3; // this is how many icons are on each wheel

			// this builds the grid 
			string[,] grid = new string[numberOfReels, numberOfSymbols];

			// we fill up our square with ? to start
			for (int reel = 0; reel < numberOfReels; reel++) // for each spinning wheel
			{
				for (int symbol = 0; symbol < numberOfSymbols; symbol++) // for each icon on the wheel
				{
					grid[reel, symbol] = "?"; // we start with a ? placeholder
				}
			}

			// displays initial grid
			DisplaySlotGrid(grid);

			// animates each reel
			for (int reel = 0; reel < numberOfReels; reel++)
			{
				DateTime endTime = DateTime.Now.AddSeconds(3);
				while (DateTime.Now < endTime)
				{
					// update each symbol in the current reel
					for (int symbol = 0; symbol < numberOfSymbols; symbol++)
					{
						grid[reel, symbol] = slots[reel][random.Next(slots[reel].Length)];
					}

					// display updated reel
					DisplaySlotGrid(grid);
					System.Threading.Thread.Sleep(100); // Delay for animation
				}
			}

			// set final symbols
			for (int reel = 0; reel < numberOfReels; reel++)
			{
				for (int symbol = 0; symbol < numberOfSymbols; symbol++)
				{
					grid[reel, symbol] = slots[reel][random.Next(slots[reel].Length)];
				}
			}

			// Display final grid
			DisplaySlotGrid(grid);

			// Check for winning condition (middle row alignment)
			bool isMiddleRowWin = grid[0, 1] == grid[1, 1] && grid[1, 1] == grid[2, 1];

			// Initialize a variable to hold the win multiplier
			double winMultiplier = 0;

			// Define a method to calculate the payout based on the symbol
			double CalculatePayout(string symbol)
			{
				switch (symbol)
				{
					case "🍒": return 5.0 * 20; // Example: cherry has a base price of 5 chips, and the win multiplier is 20.
												// Add more cases for different symbols as needed
					default: return 0; // No win
				}
			}

			if (isMiddleRowWin)
			{
				Console.WriteLine("Congratulations! You won!");
				winMultiplier = CalculatePayout(grid[1, 1]); // Calculate the payout based on the winning symbol in the middle row
			}
			// Optionally, add logic for diagonal win checks and adjust winMultiplier accordingly

			else
			{
				Console.WriteLine("Better luck next time!");
			}

			// Example: Update player's chips based on winMultiplier
			if (winMultiplier > 0)
			{
				player.chips += winMultiplier; // Assuming Player class has a chips property to track player's balance
				Console.WriteLine($"You won {winMultiplier} chips!");
			}

			Console.ReadKey();
		}

		private void DisplaySlotGrid(string[,] grid)
		{
			Console.Clear(); // Clears the console once to draw the grid layout
			Console.WriteLine("Spinning the reels...\n");
			for (int symbol = 0; symbol < grid.GetLength(1); symbol++)
			{
				for (int reel = 0; reel < grid.GetLength(0); reel++)
				{
					Console.Write(grid[reel, symbol] + "   "); // Adjust spacing as needed
				}
				Console.WriteLine("\n");
			}
		}
    }
}
