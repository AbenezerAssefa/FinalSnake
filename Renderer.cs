using System;

namespace Renderer
{
    public class Renderer
    {
        public void Draw(Snake snake, Food food, int width, int height)
        {
            Console.Clear();
            DrawBorders(width, height);
            DrawSnake(snake);
            DrawFood(food);
        }

        private void DrawBorders(int width, int height)
        {
            for (int i = 0; i < width; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write("■");
                Console.SetCursorPosition(i, height - 1);
                Console.Write("■");
            }

            for (int i = 0; i < height; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("■");
                Console.SetCursorPosition(width - 1, i);
                Console.Write("■");
            }
        }

        private void DrawSnake(Snake snake)
        {
            foreach (var pixel in snake.Body)
            {
                Console.SetCursorPosition(pixel.X, pixel.Y);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("■");
            }
        }

        private void DrawFood(Food food)
        {
            foreach (var foodItem in food.Items)
            {
                Console.SetCursorPosition(foodItem.Position.X, foodItem.Position.Y);
                Console.ForegroundColor = foodItem.Type == FoodType.Normal ? ConsoleColor.Cyan : ConsoleColor.Magenta;
                Console.Write("■");
            }
        }
    }
}
