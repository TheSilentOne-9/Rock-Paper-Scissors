using System;

namespace RockPaperScissors
{
    class Program
    {
        // Instantiating Random at the class level ensures true randomness and better performance
        static readonly Random rnd = new Random();

        static void Main(string[] args)
        {
            string[] validMoves = { "R", "P", "S" };
            int playerScore = 0, aiScore = 0;

            Console.WriteLine("Welcome to Rock, Paper, Scissors!");
            Console.WriteLine("Rules: Enter 'R' for Rock, 'P' for Paper, 'S' for Scissors.");
            Console.WriteLine("Press '0' at any time to exit.\n");

            // Main game loop
            while (true)
            {
                Console.Write("Your move (R/P/S) or '0' to quit: ");
                string playerChoice = Console.ReadLine()?.ToUpper();

                // Handle game exit
                if (playerChoice == "0")
                {
                    Console.WriteLine("\nThat was fun... goodbye! :)");
                    break;
                }

                // Input validation
                if (playerChoice != "R" && playerChoice != "P" && playerChoice != "S")
                {
                    Console.WriteLine("Invalid character. Please enter R, P, or S...\n");
                    continue;
                }

                // AI makes a random move
                string aiChoice = validMoves[rnd.Next(validMoves.Length)];

                // Evaluate the round and update scores
                DetermineWinner(playerChoice, aiChoice, ref playerScore, ref aiScore);

                // Display current score using string interpolation
                Console.WriteLine($"Score ::>> You {playerScore} - {aiScore} AI\n");
            }
        }

        /// Compares the player's move against the AI's move to determine the round winner.
        static void DetermineWinner(string player, string ai, ref int playerScore, ref int aiScore)
        {
            // Convert the AI's shorthand string into a full word for a better user experience
            string aiMoveName = ai == "R" ? "Rock" : (ai == "P" ? "Paper" : "Scissors");

            if (player == ai)
            {
                Console.WriteLine($"AI chose {aiMoveName}. It's a draw...");
            }
            // Check all win conditions for the player
            else if ((player == "R" && ai == "S") ||
                     (player == "S" && ai == "P") ||
                     (player == "P" && ai == "R"))
            {
                Console.WriteLine($"AI chose {aiMoveName}. Congratulations, you win!");
                playerScore++;
            }
            // If it's not a draw and the player didn't win, the AI wins
            else
            {
                Console.WriteLine($"AI chose {aiMoveName}. You lost!");
                aiScore++;
            }
        }
    }
}