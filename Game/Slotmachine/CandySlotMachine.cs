using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Royal_Flush_Casino.Game.Slotmachine
{
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
