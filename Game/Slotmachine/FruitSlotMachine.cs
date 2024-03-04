using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Royal_Flush_Casino.Game.Slotmachine
{
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
}
