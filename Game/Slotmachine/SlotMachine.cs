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
					 // Ensure this method is called correctly
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
            Console.WriteLine("Spinning the reels...");

            // spins the solts 
            string[] result = SpinSlots();

            // Display the result
            Console.WriteLine("Result:");

            foreach (string symbol in result)
            {
                Console.WriteLine(symbol);
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
