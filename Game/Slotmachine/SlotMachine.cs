using Royal_Flush_Casino.Game.Slotmachine;
using System;
using System.Numerics;
using static System.Reflection.Metadata.BlobBuilder;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Royal_Flush_Casino.Game
{
    internal class SlotMachine
    {
        protected string[][] slots;

        public static void ChooseSlotMachine(Player Player) 
        {
			Console.WriteLine("Welcome to slotmachine!");

			// Display sports options
			Console.WriteLine("Choose the slotmachine you want to use:");
			Console.WriteLine("1. FruitSlotMachine");
			Console.WriteLine("2. SpaceSlotMachine");
			Console.WriteLine("3. Exit");

			string slotMachineSelector = Console.ReadLine();

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

		// This is virtual because otherwise it cant be overriden
		public virtual void Play(Player player)
		{
			Random random = new Random();
			int numberOfReels = 3;
			int numberOfSymbols = 3; // Assuming a 3x3 grid
			string[,] grid = new string[numberOfReels, numberOfSymbols];

			// Initialize grid with starting symbols
			for (int reel = 0; reel < numberOfReels; reel++)
			{
				for (int symbol = 0; symbol < numberOfSymbols; symbol++)
				{
					grid[reel, symbol] = "🍒"; // Starting with cherries, for example
				}
			}

			// Display initial grid
			DisplaySlotGrid(grid);

			// Animate each reel
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
			Console.WriteLine("\nPress any key to continue...");
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




		private string[] SpinSlots()
        {
            Random random = new Random();
            string[] result = new string[slots.Length];

            for (int i = 0; i < slots.Length; i++)
            {
                int randomIndex = random.Next(0, slots[i].Length);
                result[i] = slots[i][randomIndex];
            }

            return result;
        }
    }
}
