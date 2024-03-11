﻿using System;
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
			// Set a specific cost for spinning this fruit slot machine.
			this.spinCost = 5.0; // Directly assign the value to the protected field/property

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
			Console.WriteLine("Playing the fruit-themed slot machine...");

			bool keepPlaying = true;

			while (keepPlaying)
			{
				Console.WriteLine($"You currently have: {player.chips} chips.");
				Console.WriteLine($"The price is: {this.spinCost} chips, is that alright? (yes/no)");
				string response = Console.ReadLine().Trim().ToLower();

				if (response == "yes")
				{
					if (player.chips >= this.spinCost)
					{
						player.chips -= this.spinCost; // Deduct the spin cost
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
					Console.WriteLine("Maybe next time.");
					keepPlaying = false; // Player chose not to play
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
