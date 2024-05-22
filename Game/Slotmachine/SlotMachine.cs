using Royal_Flush_Casino.Game.Slotmachine;
using System;
using System.Collections.Generic;
using Royal_Flush_Casino.Utility;

namespace Royal_Flush_Casino.Game
{
	// Defines the base for a slot machine game
	internal class SlotMachine
	{
		// Protected array of slot symbols for inheritance
		protected string[][] slots = Array.Empty<string[]>(); // Initialize to an empty array to avoid null references

		// The cost to play a single spin on this slot machine. This can be overridden by other slot machine classes.
		protected double spinCost = 5;

		// Dictionary for the icons to assign a multiplier
		protected Dictionary<string, double> symbolPayouts = new Dictionary<string, double>();

		// Constructor that initializes/makes a setup of the base slot symbols
		public SlotMachine()
		{
			// These are the base slot machine symbols
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

		protected double baseMultiplier = 20;

		protected double CalculatePayout(string symbol)
		{
			if (symbolPayouts.TryGetValue(symbol, out double multiplier))
			{
				return multiplier * baseMultiplier;
			}
			return 0; // No win
		}

		public virtual void Play(Player player)
		{
			Random random = new Random();
			int numberOfReels = 3; // How many reels/wheels the slot machines have
			int numberOfSymbols = 3; // This is how many icons are on each wheel

			// This builds the grid 
			string[,] grid = new string[numberOfReels, numberOfSymbols];

			// We fill up our square with ? to start
			for (int reel = 0; reel < numberOfReels; reel++) // For each spinning wheel
			{
				for (int symbol = 0; symbol < numberOfSymbols; symbol++) // For each icon on the wheel
				{
					grid[reel, symbol] = "?"; // We start with a ? placeholder
				}
			}

			// Displays initial grid
			DisplaySlotGrid(grid);

			// Animates each reel
			for (int reel = 0; reel < numberOfReels; reel++)
			{
				DateTime endTime = DateTime.Now.AddSeconds(3);
				while (DateTime.Now < endTime)
				{
					// Update each symbol in the current reel
					for (int symbol = 0; symbol < numberOfSymbols; symbol++)
					{
						grid[reel, symbol] = slots[reel][random.Next(slots[reel].Length)];
					}

					// Display updated reel
					DisplaySlotGrid(grid);
					System.Threading.Thread.Sleep(100); // Delay for animation
				}
			}

			// Set final symbols
			for (int reel = 0; reel < numberOfReels; reel++)
			{
				for (int symbol = 0; symbol < numberOfSymbols; symbol++)
				{
					grid[reel, symbol] = slots[reel][random.Next(slots[reel].Length)];
				}
			}

			// Display final grid
			DisplaySlotGrid(grid);

			// Win checks (rows and diagonals)
			bool isUpperRowWin = grid[0, 0] == grid[1, 0] && grid[1, 0] == grid[2, 0];
			bool isMiddleRowWin = grid[0, 1] == grid[1, 1] && grid[1, 1] == grid[2, 1];
			bool isLowerRowWin = grid[0, 2] == grid[1, 2] && grid[1, 2] == grid[2, 2];
			bool isDiagonalWinLTR = grid[0, 0] == grid[1, 1] && grid[1, 1] == grid[2, 2];
			bool isDiagonalWinRTL = grid[2, 0] == grid[1, 1] && grid[1, 1] == grid[0, 2];
			bool isAnyWin = isUpperRowWin || isMiddleRowWin || isLowerRowWin || isDiagonalWinLTR || isDiagonalWinRTL;

			if (isAnyWin)
			{
				Console.WriteLine("Congratulations! You won!");
				string winningSymbol = grid[1, 1]; // Simplified example
				double winMultiplier = CalculatePayout(winningSymbol);
				player.Chips += winMultiplier; // Update the player's chip count
				Console.WriteLine($"You won {winMultiplier} chips!");
			}
			else
			{
				Console.WriteLine("Better luck next time!");
				Console.WriteLine("Press any key to continue");
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
