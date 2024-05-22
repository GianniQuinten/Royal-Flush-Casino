using Royal_Flush_Casino.Utility;
using System;
using System.Collections.Generic;

namespace Royal_Flush_Casino.Game.Slotmachine
{
	internal class CandySlotMachine : SlotMachine
	{
		public CandySlotMachine() : base()
		{
			this.spinCost = 5.0;
		}

		protected override void InitializeBaseSymbolsAndPayouts()
		{
			slots = new string[][]
			{
				new string[] { "🍭", "🐻", "🍫", "🍬" },
				new string[] { "🍬", "🍭", "🐻", "🍫" },
				new string[] { "🍫", "🍬", "🍭", "🐻" }
			};

			symbolPayouts = new Dictionary<string, double>
			{
				{ "🍭", 15.0 },
				{ "🐻", 1.0 },
				{ "🍫", 10.0 },
				{ "🍬", 2.0 }
			};
		}

		public override void Play(Player player)
		{
			Console.WriteLine("playing the candy-themed slot machine...");

			bool keepPlaying = true;

			while (keepPlaying)
			{
				Console.WriteLine($"you currently have: {player.Chips} chips.");
				Console.WriteLine($"do you wish to play for: {this.spinCost} chips? (yes/no)");
				string response = Console.ReadLine()?.Trim().ToLower() ?? ""; // use null-coalescing operator to handle null response

				if (response == "yes")
				{
					base.Play(player);
				}
				else if (response == "no")
				{
					Console.Clear();
					GameSelector.ChooseSlotMachine(player);
				}
				else
				{
					Console.WriteLine("invalid response. please answer 'yes' or 'no'.");
				}
			}
		}
	}
}
