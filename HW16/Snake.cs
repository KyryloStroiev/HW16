using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW16;

public class Snake
{
    public List<Position> WholeBody;
    public Position Head => WholeBody.First();
    public IEnumerable<Position> Body => WholeBody.Skip(1);
    public int GrowthRemaining;
    public bool IsAlive { get; set; } = true;
    public Snake(Position location, int size = 1)
    {
        WholeBody = new List<Position> {location};
        GrowthRemaining = Math.Max(0, size - 1);
    }
    public void Move(Direction direction)
    {
        if (!IsAlive) throw new Exception("");
        Position newHead = direction switch
        {
            Direction.Up => Head.DownBy(-1),
            Direction.Down => Head.DownBy(1),
            Direction.Left => Head.RightBy(-1),
            Direction.Right => Head.RightBy(1),
            _ => throw new Exception(""),
        };
        if(WholeBody.Contains(newHead) || !IsPositionValid(newHead))
        {
            IsAlive = false;
            return;
        }
        WholeBody.Insert(0, newHead);
        if (GrowthRemaining > 0) GrowthRemaining--;
        else WholeBody.RemoveAt(WholeBody.Count -1);
    }
    public void Grow()
    {
        if (!IsAlive) throw new Exception("");
        GrowthRemaining++;
    }
    public void Render()
    {
        Console.SetCursorPosition(Head.Left, Head.Top);
        Console.WriteLine("○");
        foreach (var elem in Body)
        {
            Console.SetCursorPosition(elem.Left, elem.Top);
            Console.WriteLine("●");
        }
    }
    public bool IsPositionValid(Position pos) =>
        pos.Top >= 0 && pos.Left >= 0;
}
