using Royal_Flush_Casino.Game.Slotmachine;
using System;
using Royal_Flush_Casino.Utility;


namespace Royal_Flush_Casino.Game
{
	// defines the base for a slotmachine game
	internal class SlotMachine
    {
		// protected array of slot symbols for inheritance
		protected string[][] slots;

		// The cost to play a single spin on this slot machine. This can be overridden by other slotmachine classes.
		protected double spinCost = 5;

		// dictionary for the icons to assign a multiplier
		protected Dictionary<string, double> symbolPayouts = new Dictionary<string, double>();

		// selector to choose slotmachine
		private void ChooseSlotMachine(Player player)
		{
			// Directly invoke the GameSelector's method to choose the slot machine
			// Make sure GameSelector is accessible from this context
			GameSelector.ChooseSlotMachine(player);
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

			// Base multipliers - can be overridden in derived classes
			symbolPayouts.Add("🍒", 5.0);
			symbolPayouts.Add("🍇", 5.0);
			symbolPayouts.Add("🍓", 5.0);
			symbolPayouts.Add("🍉", 5.0);
		}

			

		double winMultiplier = 0;
		double baseMultiplier = 20;

		protected double CalculatePayout(string symbol)
		{
			if (symbolPayouts.TryGetValue(symbol, out double multiplier))
			{
				return multiplier * baseMultiplier; // Assuming baseMultiplier is defined elsewhere
			}
			return 0; // No win
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
			// Display final grid
			DisplaySlotGrid(grid);

			// Win checks (rows and diagonals)
			bool isUpperRowWin = grid[0, 0] == grid[1, 0] && grid[1, 0] == grid[2, 0];
			bool isMiddleRowWin = grid[0, 1] == grid[1, 1] && grid[1, 1] == grid[2, 1];
			bool isLowerRowWin = grid[0, 2] == grid[1, 2] && grid[1, 2] == grid[2, 2];
			bool isDiagonalWinLTR = grid[0, 0] == grid[1, 1] && grid[1, 1] == grid[2, 2];
			bool isDiagonalWinRTL = grid[2, 0] == grid[1, 1] && grid[1, 1] == grid[0, 2];
			bool isAnyWin = isUpperRowWin || isMiddleRowWin || isLowerRowWin || isDiagonalWinLTR || isDiagonalWinRTL;

			

			// Modify this part to account for all win conditions
			if (isAnyWin)
			{
				Console.WriteLine("Congratulations! You won!");
				// Assuming we prioritize diagonal wins or any win, pick a representative symbol for the win type
				string winningSymbol = isMiddleRowWin ? grid[1, 1] : grid[0, 0]; // Simplified example
				winMultiplier = CalculatePayout(winningSymbol);
				player.chips += winMultiplier; // Update the player's chip count
				Console.WriteLine($"You won {winMultiplier} chips!");
			}
			else
			{
				Console.WriteLine("Better luck next time!");
				Console.WriteLine("press any key to continue");
			}

			// Ending prompts...
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
