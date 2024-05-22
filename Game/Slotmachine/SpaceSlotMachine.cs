using Royal_Flush_Casino.Utility;
using System;

namespace Royal_Flush_Casino.Game.Slotmachine
{
	internal class SpaceSlotMachine : SlotMachine
	{
		public SpaceSlotMachine() : base()
		{
			// Set a specific cost for spinning this space-themed slot machine.
			this.spinCost = 4.0;

			// Define symbols for each reel for the space-themed slot machine
			slots = new string[][]
			{
				new string[] { "🌍", "⭐", "👽", "🚀" },
				new string[] { "🚀", "🌍", "⭐", "👽" },
				new string[] { "👽", "🚀", "🌍", "⭐" }
			};

			// Define specific multipliers for this slot machine
			symbolPayouts = new Dictionary<string, double>
			{
				{ "🌍", 15.0 },
				{ "⭐", 4.0 },
				{ "👽", 2.0 },
				{ "🚀", 9.0 }
			};
		}

		public override void Play(Player player)
		{
			Console.WriteLine("Playing the space-themed slot machine...");

			bool keepPlaying = true;

			while (keepPlaying)
			{
				Console.WriteLine($"You currently have: {player.Chips} chips.");
				Console.WriteLine($"Do you wish to play for: {this.spinCost} chips? (yes/no)");
				string response = Console.ReadLine().Trim().ToLower();

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
