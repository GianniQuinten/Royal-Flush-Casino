using System;
using static System.Reflection.Metadata.BlobBuilder;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Royal_Flush_Casino.Game
{
	internal class SlotMachine
	{
		protected string[][] slots;

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

	internal class FruitSlotMachine : SlotMachine
	{
		public FruitSlotMachine() : base()
		{
			// Define symbols for each reel for the berry-themed slot machine
			slots = new string[][]
			{
				new string[] { "🍓", "🍉", "🍒", "🍓" },
				new string[] { "🍒", "🍓", "🍉", "🍒" },
				new string[] { "🍉", "🍒", "🍓", "🍉" }
			};
		}

		public override void Play(Player player)
		{
			// Custom logic for berry-themed slot machine
			Console.WriteLine("Playing the fruit-themed slot machine...");
			base.Play(player);
		}
	}

	internal class SpaceSlotMachine : SlotMachine
	{
		public SpaceSlotMachine() : base()
		{
			// Define symbols for each reel for the diamond-themed slot machine
			slots = new string[][]
			{
				new string[] { "🌍", "⭐", "👽", "🚀" },
				new string[] { "🚀", "🌍", "⭐", "👽" },
				new string[] { "👽", "🚀", "🌍", "⭐" }
			};
		}

		public override void Play(Player player)
		{
			// Custom logic for diamond-themed slot machine
			Console.WriteLine("Playing the diamond-themed slot machine...");
			base.Play(player);
		}
	}

	internal class FantasySlotMachine : SlotMachine
	{
		public FantasySlotMachine() : base()
		{
			// Define symbols for each reel for the diamond-themed slot machine
			slots = new string[][]
			{
				new string[] { "🐉", "🦄", "🧚", "🧪" },
				new string[] { "🧪", "🐉", "🦄", "🧚" },
				new string[] { "🧚", "🧪", "🐉", "🦄" }
			};
		}

		public override void Play(Player player)
		{
			// Custom logic for diamond-themed slot machine
			Console.WriteLine("Playing the diamond-themed slot machine...");
			base.Play(player);
		}
	}

	internal class WildWestSlotMachine : SlotMachine
	{
		public WildWestSlotMachine() : base()
		{
			// Define symbols for each reel for the diamond-themed slot machine
			slots = new string[][]
			{
				new string[] { "🤠", "🔫", "💰" },
				new string[] { "💰", "🤠", "🔫" },
				new string[] { "🔫", "💰", "🤠" }
			};
		}

		public override void Play(Player player)
		{
			// Custom logic for diamond-themed slot machine
			Console.WriteLine("Playing the diamond-themed slot machine...");
			base.Play(player);
		}
	}

	internal class CandySlotMachine : SlotMachine
	{
		public CandySlotMachine() : base()
		{
			// Define symbols for each reel for the diamond-themed slot machine
			slots = new string[][]
			{
				new string[] { "🍭", "🐻", "🍫", "🍬" },
				new string[] { "🍬", "🍭", "🐻‍", "🍫" },
				new string[] { "🍫", "🍬", "🍭", "🐻‍" }
			};
		}

		public override void Play(Player player)
		{
			// Custom logic for diamond-themed slot machine
			Console.WriteLine("Playing the diamond-themed slot machine...");
			base.Play(player);
		}
	}
}
