using System;
namespace Program
{
    public class Program
    {
        //We define the maximum and the minimum possible number the dice can roll so we can quickly change these later.
        static int minimumPos = 1;
        static int maximumPos = 7;
        //We assign these variables so that we can use them elsewhere in the program.
        static int currentRound = 1;
        static int rivalScore = 0;
        static int playerScore = 0;
        public static void Main(string[] args)
        {
            Console.Clear();
            Begin();
            Console.WriteLine();
            Console.Write("Press any key to continue...");
            AwaitKeyPress();
            //We added double Console.WriteLine's because it ends the current line and we use the second one to create a space.
            Console.WriteLine();
            Console.WriteLine();
            while (currentRound <= 10)
            {
                int rivalNum = RandomNumber();
                Console.WriteLine($"Round {currentRound}");
                Console.WriteLine($"Rival rolled a {rivalNum}");
                Console.Write("Press any key to roll the dice...");
                AwaitKeyPress();
                Console.WriteLine();
                int playerNum = RandomNumber();
                Console.WriteLine($"You rolled a {playerNum}");
                if (playerNum > rivalNum)
                {
                    playerScore++;
                    Console.WriteLine("You won this round.");
                    PrintScore();
                }
                else if (playerNum == rivalNum)
                {
                    Console.WriteLine("This round is a draw!");
                    PrintScore();
                }
                else
                {
                    rivalScore++;
                    Console.WriteLine("The Rival won this round.");
                    PrintScore();
                }
                Console.Write("Press any key to continue...");
                AwaitKeyPress();
                currentRound++;
                Console.WriteLine();
                Console.WriteLine();
            }
            Console.WriteLine("Game over.");
            PrintScore();
            if (playerScore > rivalScore)
            {
                Console.WriteLine("You won!");
            }
            else if (rivalScore > playerScore)
            {
                Console.WriteLine("You lost!");
            }
            else
            {
                Console.WriteLine("You tied!");
            }
            Console.Write("Press any key to continue...");
            AwaitKeyPress();
            Console.Clear();
            Console.WriteLine("Dice Game was closed.");
            Thread.Sleep(4500);
            Environment.Exit(0);
        }
        public static void Begin()
        {
            Console.WriteLine("Dice Game");
            Console.WriteLine();
            Console.WriteLine("In this game you and a computer Rival will play 10 rounds where you will each roll a 6 - sided dice, and the player with the highest dice value will win the round.The player who wins the most rounds wins the game. Good luck!");
        }
        public static int RandomNumber()
        {
            Random rnd = new Random();
            int randomNum = rnd.Next(minimumPos, maximumPos);
            return randomNum;
        }
        public static void PrintScore()
        {
            Console.WriteLine($"The score is now - You: {playerScore}. Rival: {rivalScore}.");
        }
        public static void AwaitKeyPress()
        {
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    //This variable creates an instance when a key is pressed. We use this to determine if a key was pressed.
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    if (key != null)
                    {
                        break;
                    }
                }
            }
        }
    }
}