﻿using Royal_Flush_Casino.Utility;
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


			// Define specific multipliers for this slot machine
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
			// Custom logic for diamond-themed slot machine
			Console.WriteLine("Playing the diamond-themed slot machine...");

			bool keepPlaying = true;

			while (keepPlaying)
			{
				Console.WriteLine($"You currently have: {player.Chips} chips.");
				Console.WriteLine($"The price is: {this.spinCost} chips, is that alright? (yes/no)");
				string response = Console.ReadLine().Trim().ToLower();

				if (response == "yes")
				{
					if (player.Chips >= this.spinCost)
					{
						player.Chips -= this.spinCost; // Deduct the spin cost
						Console.WriteLine("Great! Let's play.");

						base.Play(player); // Actual game play happens here
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
					// This allows the loop to re-prompt the player without altering the keepPlaying flag.
				}
			}
		}
	}
}
