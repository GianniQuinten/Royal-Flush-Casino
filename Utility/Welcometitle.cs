using System;

namespace Royal_Flush_Casino.Utility
{
	internal class Welcometitle
	{
		public static void DisplayTitle()
		{
			string[] titleLines = {
				"8888888b.                            888      8888888888 888                   888            .d8888b.                    d8b",
				"888   Y88b                           888      888        888                   888           d88P  Y88b                   Y8P",
				"888    888                           888      888        888                   888           888    888",
				"888   d88P .d88b.  888  888  8888b.  888      8888888    888 888  888 .d8888b  88888b.       888         8888b.  .d8888b  888 88888b.   .d88b.",
				"8888888P\" d88\"\"88b 888  888     \"88b 888      888        888 888  888 88K      888 \"88b      888            \"88b 88K      888 888 \"88b d88\"\"88b",
				"888 T88b  888  888 888  888 .d888888 888      888        888 888  888 \"Y8888b. 888  888      888    888 .d888888 \"Y8888b. 888 888  888 888  888",
				"888  T88b Y88..88P Y88b 888 888  888 888      888        888 Y88b 888      X88 888  888      Y88b  d88P 888  888      X88 888 888  888 Y88..88P",
				"888   T88b \"Y88P\"   \"Y88888 \"Y888888 888      888        888  \"Y88888  88888P' 888  888       \"Y8888P\"  \"Y888888  88888P' 888 888  888  \"Y88P\"",
				"                       888",
				"                   Y8b d88P",
				"                    \"Y88P\""
			};

			// The reason for the foreach loop is because the old code would not render the console properly after maximizing the window
			foreach (string line in titleLines)
			{
				Console.WriteLine(line);
			}
		}

		public static void DisplayWelcome()
		{
			Console.WriteLine("Welcome to Royal Flush Casino!");
		}
	}
}
