using Royal_Flush_Casino.Utility;
using System;

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
			Console.WriteLine("Playing the candy-themed slot machine...");

			bool keepPlaying = true;

			while (keepPlaying)
			{
				Console.WriteLine($"You currently have: {player.Chips} chips.");
				Console.WriteLine($"Do you wish to play for: {this.spinCost} chips? (yes/no)");
				string response = Console.ReadLine()?.Trim().ToLower() ?? ""; // Use null-coalescing operator to handle null response

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
					Console.WriteLine("Invalid response. Please answer 'yes' or 'no'.");
				}
			}
		}
	}
}
