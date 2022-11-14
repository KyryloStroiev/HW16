using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW16;

public class Apple
{
    public Position Position { get; set; }

    public Apple(Position position)
    {
        Position = position;
    }
    public void Render()
    {
        Console.SetCursorPosition(Position.Left, Position.Top);
        Console.WriteLine("Δ");
    }
}

public static class AppleExtentions
{
    public static Apple CreatApple()
    {
        var rows = 20;
        var colums = 20;
        var random = new Random();
        var top = random.Next(0, rows + 2);
        var left = random.Next(0,colums + 2);
        return new Apple(new Position(top, left));
    }
}


