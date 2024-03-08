using System;

namespace Royal_Flush_Casino.Game
{
    internal class Football
    {
        public static void BetOnFootball()
        {
            // Sample list of 20 football teams
            List<string> teams = new List<string>
        {
            "Almere City", "Ajax", "PSV", "Feyenoord", "AZ",
            "Manchester City", "Liverpool", "Arsenal", "Manchster United", "Chelsea"
        };

            // Select teams
            Console.WriteLine("Select two teams to play:");

            for (int i = 0; i < teams.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {teams[i]}");
            }

            Console.Write("Enter the number of the first team: ");
            int teamIndex1 = int.Parse(Console.ReadLine()) - 1;
            Console.Write("Enter the number of the second team: ");
            int teamIndex2 = int.Parse(Console.ReadLine()) - 1;

            string teamA = teams[teamIndex1];
            string teamB = teams[teamIndex2];

            // Simulate match
            Random random = new Random();
            int goalsA = random.Next(6); // Random goals scored by Team A (0 to 5)
            int goalsB = random.Next(6); // Random goals scored by Team B (0 to 5)

            // Determine the winner or draw
            string winner;
            if (goalsA > goalsB)
            {
                winner = teamA;
            }
            else if (goalsB > goalsA)
            {
                winner = teamB;
            }
            else
            {
                winner = "Draw";
            }

            // Display match result
            Console.WriteLine($"Match: {teamA} {goalsA} - {goalsB} {teamB}, Winner: {winner}");
        }
    }
}
