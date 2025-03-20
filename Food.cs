using System;
using System.Collections.Generic;
using assignemtforC.Entities;
using assignemtforC.Enum;

public class Food
{
    public List<FoodItem> Items { get; private set; }

    public Food(int maxX, int maxY, Random random)
    {
        Items = new List<FoodItem>();
        GenerateNewItems(maxX, maxY, random);
    }

    public void GenerateNewItems(int maxX, int maxY, Random random)
    {
        Items.Clear();

        // Generate one regular berry and one poisoned berry
        Items.Add(new FoodItem(new Point2D(random.Next(1, maxX - 2), random.Next(1, maxY - 2)), FoodType.Normal));
        Items.Add(new FoodItem(new Point2D(random.Next(1, maxX - 2), random.Next(1, maxY - 2)), FoodType.Poisoned));
    }
}
