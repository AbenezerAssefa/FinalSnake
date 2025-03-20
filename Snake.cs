using System;
using System.Collections.Generic;
using assignemtforC.Entities;
using assignemtforC.Enum;

public class Snake
{
    public List<Point2D> Body { get; private set; }
    public Direction Direction { get; private set; }

    public Snake(int startX, int startY, ConsoleColor color, int initialLength)
    {
        Body = new List<Point2D>();
        for (int i = 0; i < initialLength; i++)
        {
            Body.Add(new Point2D(startX - i, startY));
        }
        Direction = Direction.Right;
    }

    public void Move()
    {
        var head = Body.Last();
        int newX = head.X;
        int newY = head.Y;

        switch (Direction)
        {
            case Direction.Up:
                newY--;
                break;
            case Direction.Down:
                newY++;
                break;
            case Direction.Left:
                newX--;
                break;
            case Direction.Right:
                newX++;
                break;
        }

        Body.Add(new Point2D(newX, newY));
        Body.RemoveAt(0);
    }

    public void ChangeDirection(Direction newDirection)
    {
        // Prevent reversing direction
        if ((Direction == Direction.Up && newDirection != Direction.Down) ||
            (Direction == Direction.Down && newDirection != Direction.Up) ||
            (Direction == Direction.Left && newDirection != Direction.Right) ||
            (Direction == Direction.Right && newDirection != Direction.Left))
        {
            Direction = newDirection;
        }
    }

    public void Grow()
    {
        var tail = Body.First();
        Body.Insert(0, new Point2D(tail.X, tail.Y));
    }
}
