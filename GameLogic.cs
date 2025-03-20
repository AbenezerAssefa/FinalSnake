using System;
using System.Threading;
using assignemtforC.Entities;
using assignemtforC.Enum;
using assignemtforC.Renderer;
using assignemtforC;

public class GameLogic
{
    private Snake snake;
    private Food food;
    private Renderer.Renderer renderer;
    private int score;
    private int width;
    private int height;
    private Random random;
    private bool isGameOver;

    public GameLogic(int width, int height)
    {
        this.width = width;
        this.height = height;
        snake = new Snake(width / 2, height / 2, ConsoleColor.Red, 1);
        random = new Random();
        food = new Food(width, height, random);
        renderer = new Renderer.Renderer();
        score = 1;
        isGameOver = false;
    }

    public void Run(Difficulty difficulty)
    {
        while (!isGameOver)
        {
            renderer.Draw(snake, food, width, height);
            HandleInput();
            snake.Move();
            CheckCollisions();
            Thread.Sleep((int)difficulty);
        }
        ShowGameOverScreen();
    }

    private void HandleInput()
    {
        if (Console.KeyAvailable)
        {
            ConsoleKeyInfo key = Console.ReadKey(true);
            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    snake.ChangeDirection(Direction.Up);
                    break;
                case ConsoleKey.DownArrow:
                    snake.ChangeDirection(Direction.Down);
                    break;
                case ConsoleKey.LeftArrow:
                    snake.ChangeDirection(Direction.Left);
                    break;
                case ConsoleKey.RightArrow:
                    snake.ChangeDirection(Direction.Right);
                    break;
            }
        }
    }

    private void CheckCollisions()
    {
        var head = snake.Body.Last();

        if (IsCollisionWithWall(head))
        {
            isGameOver = true;
            return;
        }

        if (IsCollisionWithSelf(head))
        {
            isGameOver = true;
            return;
        }

        HandleFoodCollisions(head);
    }

    private bool IsCollisionWithWall(Point2D head)
    {
        return head.X <= 0 || head.X >= width - 1 || head.Y <= 0 || head.Y >= height - 1;
    }

    private bool IsCollisionWithSelf(Point2D head)
    {
        for (int i = 0; i < snake.Body.Count - 1; i++)
        {
            if (snake.Body[i].X == head.X && snake.Body[i].Y == head.Y)
            {
                return true;
            }
        }
        return false;
    }

    private void HandleFoodCollisions(Point2D head)
    {
        foreach (var foodItem in food.Items)
        {
            if (head.X == foodItem.Position.X && head.Y == foodItem.Position.Y)
            {
                if (foodItem.Type == FoodType.Normal)
                {
                    snake.Grow();
                    score++;
                }
                else
                {
                    isGameOver = true;
                }

                food.GenerateNewItems(width, height, random);
                return;
            }
        }
    }

    private void ShowGameOverScreen()
    {
        Console.Clear();
        Console.SetCursorPosition(width / 3, height / 2);
        Console.WriteLine("Game Over! Score: " + score);
        Console.SetCursorPosition(width / 3, height / 2 + 1);
        Environment.Exit(0);
    }
}
