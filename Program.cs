using System;
using assignemtforC;

public class Program
{
    public static void Main(string[] args)
    {
        int width = Console.WindowWidth;
        int height = Console.WindowHeight;

        // Select difficulty
        Difficulty difficulty = SelectDifficulty();

        // Initialize and run the game
        GameLogic game = new GameLogic(width, height);
        game.Run(difficulty);
    }

    public static Difficulty SelectDifficulty()
    {
        Console.WriteLine("Select Difficulty:");
        Console.WriteLine("1. Easy");
        Console.WriteLine("2. Medium");
        Console.WriteLine("3. Hard");

        while (true)
        {
            ConsoleKeyInfo key = Console.ReadKey(true);
            switch (key.Key)
            {
                case ConsoleKey.D1:
                    return Difficulty.Easy;
                case ConsoleKey.D2:
                    return Difficulty.Medium;
                case ConsoleKey.D3:
                    return Difficulty.Hard;
                default:
                    Console.WriteLine("Invalid choice. Please select 1, 2, or 3.");
                    break;
            }
        }
    }
}
