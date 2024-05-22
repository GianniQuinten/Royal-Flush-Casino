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

		// Constructor
		public SlotMachine()
		{
			InitializeBaseSymbolsAndPayouts();
		}

		// Method to initialize base symbols and payouts
		protected virtual void InitializeBaseSymbolsAndPayouts()
		{
			slots = new string[][]
			{
				new string[] { "🍒", "🍇", "🍓", "🍉" },
				new string[] { "🍒", "🍇", "🍓", "🍉" },
				new string[] { "🍒", "🍇", "🍓", "🍉" }
			};

			symbolPayouts = new Dictionary<string, double>
			{
				{ "🍒", 5.0 },
				{ "🍇", 5.0 },
				{ "🍓", 5.0 },
				{ "🍉", 5.0 }
			};
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
			if (!DeductSpinCost(player))
			{
				Console.WriteLine("Too bad, you do not have enough chips.");
				return;
			}

			Random random = new Random();
			int numberOfReels = 3;
			int numberOfSymbols = 3;

			string[,] grid = InitializeGrid(numberOfReels, numberOfSymbols);
			AnimateReels(grid, random, numberOfReels, numberOfSymbols);
			DisplaySlotGrid(grid);

			CheckForWins(grid, player);
		}

		private bool DeductSpinCost(Player player)
		{
			if (player.Chips >= this.spinCost)
			{
				player.Chips -= this.spinCost;
				return true;
			}
			return false;
		}

		private string[,] InitializeGrid(int numberOfReels, int numberOfSymbols)
		{
			string[,] grid = new string[numberOfReels, numberOfSymbols];
			for (int reel = 0; reel < numberOfReels; reel++)
			{
				for (int symbol = 0; symbol < numberOfSymbols; symbol++)
				{
					grid[reel, symbol] = "?";
				}
			}
			DisplaySlotGrid(grid);
			return grid;
		}

		private void AnimateReels(string[,] grid, Random random, int numberOfReels, int numberOfSymbols)
		{
			for (int reel = 0; reel < numberOfReels; reel++)
			{
				DateTime endTime = DateTime.Now.AddSeconds(3);
				while (DateTime.Now < endTime)
				{
					for (int symbol = 0; symbol < numberOfSymbols; symbol++)
					{
						grid[reel, symbol] = slots[reel][random.Next(slots[reel].Length)];
					}
					DisplaySlotGrid(grid);
					System.Threading.Thread.Sleep(100);
				}
			}

			for (int reel = 0; reel < numberOfReels; reel++)
			{
				for (int symbol = 0; symbol < numberOfSymbols; symbol++)
				{
					grid[reel, symbol] = slots[reel][random.Next(slots[reel].Length)];
				}
			}
		}

		private void CheckForWins(string[,] grid, Player player)
		{
			bool isUpperRowWin = grid[0, 0] == grid[1, 0] && grid[1, 0] == grid[2, 0];
			bool isMiddleRowWin = grid[0, 1] == grid[1, 1] && grid[1, 1] == grid[2, 1];
			bool isLowerRowWin = grid[0, 2] == grid[1, 2] && grid[1, 2] == grid[2, 2];
			bool isDiagonalWinLTR = grid[0, 0] == grid[1, 1] && grid[1, 1] == grid[2, 2];
			bool isDiagonalWinRTL = grid[2, 0] == grid[1, 1] && grid[1, 1] == grid[0, 2];
			bool isAnyWin = isUpperRowWin || isMiddleRowWin || isLowerRowWin || isDiagonalWinLTR || isDiagonalWinRTL;

			if (isAnyWin)
			{
				Console.WriteLine("Congratulations! You won!");
				string winningSymbol = grid[1, 1];
				double winMultiplier = CalculatePayout(winningSymbol);
				player.Chips += winMultiplier;
				Console.WriteLine($"You won {winMultiplier} chips!");
			}
			else
			{
				Console.WriteLine("Better luck next time!");
				Console.WriteLine("Press any key to continue");
			}

			Console.ReadKey();
		}

		protected void DisplaySlotGrid(string[,] grid)
		{
			Console.Clear();
			Console.WriteLine("Spinning the reels...\n");
			for (int symbol = 0; symbol < grid.GetLength(1); symbol++)
			{
				for (int reel = 0; reel < grid.GetLength(0); reel++)
				{
					Console.Write(grid[reel, symbol] + "   ");
				}
				Console.WriteLine("\n");
			}
		}
	}
}
