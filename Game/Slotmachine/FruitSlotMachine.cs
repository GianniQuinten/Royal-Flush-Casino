using Royal_Flush_Casino.Utility;
using System;

namespace Royal_Flush_Casino.Game.Slotmachine
{
	internal class FruitSlotMachine : SlotMachine
	{
		public FruitSlotMachine() : base()
		{
			// Set a specific cost for spinning this fruit slot machine.
			this.spinCost = 5.0;

			// Define symbols for each reel for the berry-themed slot machine
			slots = new string[][]
			{
				new string[] { "🍎", "🍌", "🍍", "🍇" },
				new string[] { "🍎", "🍌", "🍍", "🍇" },
				new string[] { "🍎", "🍌", "🍍", "🍇" }
			};

			// Define specific multipliers for this slot machine
			symbolPayouts = new Dictionary<string, double>
			{
				{ "🍎", 10.0 },
				{ "🍌", 8.0 },
				{ "🍍", 12.0 },
				{ "🍇", 6.0 }
			};
		}

		public override void Play(Player player)
		{
			Console.WriteLine("Playing the fruit-themed slot machine...");

			bool keepPlaying = true;

			while (keepPlaying)
			{
				Console.WriteLine($"You currently have: {player.Chips} chips.");
				Console.WriteLine($"Do you wish to play for: {this.spinCost} chips? (yes/no)");
				string response = Console.ReadLine()?.Trim().ToLower() ?? ""; // Use null-coalescing operator to handle null response

				if (response == "yes")
				{
					if (player.Chips >= this.spinCost)
					{
						player.Chips -= this.spinCost; // Deduct the spin cost
						Console.WriteLine("Great! Let's play.");

						base.Play(player); // Actual gameplay happens here
						keepPlaying = true;
					}
					else
					{
						Console.WriteLine("Too bad, you do not have enough chips.");
						keepPlaying = false; // Player can't continue playing due to insufficient chips
					}
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
